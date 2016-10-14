using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Remoting.Messaging;

namespace Repositories
{
    /// <summary>
    /// 定义通用的Repository
    /// </summary>
    /// <typeparam name="T">定义泛型，约束其是一个类</typeparam>
    public class Repository<T> : IRepository<T> where T : class ,new()
    {
        #region 上下文

        public DataContext db { get; set; }

        public Repository()
        {
            this.db = (DataContext)CallContext.GetData("DataContext");
            if (this.db == null)
            {
                this.db = new DataContext();
                //延迟加载  true开启
                db.Configuration.LazyLoadingEnabled = true;
                CallContext.SetData("DataContext", this.db);
            }
        }

        #endregion 上下文

        #region 公共方法

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 检查异常
        /// </summary>
        /// <returns></returns>
        private int SaveChanges()
        {
            try
            {
                return db.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #endregion 实现释放接口

        #region 1.0增加一条记录

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="model">实体类</param>
        /// <returns>int 影响行数</returns>
        public int Insert(T model)
        {
            db.Set<T>().Add(model);
            return SaveChanges();
        }

        #endregion

        #region 2.0根据条件删除所有记录

        /// <summary>
        /// 根据条件删除所有记录
        /// </summary>
        /// <returns>int 影响行数</returns>
        public int Delete()
        {
            List<T> listDels = db.Set<T>().ToList();
            listDels.ForEach(i =>
            {
                db.Set<T>().Attach(i);
                db.Set<T>().Remove(i);
            });
            return SaveChanges();
        }

        #endregion

        #region 2.1删除一条记录

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="model">实体类</param>
        /// <returns>int 影响行数</returns>
        public int Delete(T model)
        {
            db.Set<T>().Attach(model);
            db.Set<T>().Remove(model);
            return SaveChanges();
        }

        #endregion

        #region 2.2根据条件删除N条记录

        /// <summary>
        /// 根据条件删除N条记录
        /// </summary>
        /// <param name="whereLambda">删除条件</param>
        /// <returns>int 影响行数</returns>
        public int Delete(Expression<Func<T, bool>> whereLambda)
        {
            List<T> listDels = db.Set<T>().Where(whereLambda).ToList();
            listDels.ForEach(i =>
            {
                db.Set<T>().Attach(i);
                db.Set<T>().Remove(i);
            });
            return SaveChanges();
        }

        #endregion

        #region 3.0修改一条记录的某些字段

        /// <summary>
        /// 修改一条记录的某些字段
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="model">实体类</param>
        /// <param name="pNames">具体修改的字段</param>
        /// <returns>int 影响行数</returns>
        public int Modidy(T model, params string[] pNames)
        {
            DbEntityEntry entry = db.Entry<T>(model);
            if (pNames.Count() > 0)
            {
                entry.State = EntityState.Unchanged;
                foreach (string pName in pNames)
                {
                    entry.Property(pName).IsModified = true;
                }
            }
            else
            {
                entry.State = EntityState.Modified;
            }
            return SaveChanges();
        }

        #endregion

        #region 3.1批量修改多条记录的某些字段

        /// <summary>
        /// 批量修改多条记录的某些字段
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="model">实体类</param>
        /// <param name="whereLambda">修改条件</param>
        /// <param name="pNames">具体修改的字段</param>
        /// <returns>int 影响行数</returns>
        public int Modidy(T model, Expression<Func<T, bool>> whereLambda, params string[] pNames)
        {
            List<T> listModifies = null;
            if (whereLambda != null)
            {
                listModifies = db.Set<T>().Where(whereLambda).ToList();
            }
            else
            {
                listModifies = db.Set<T>().ToList();
            }
            Type t = typeof(T);
            List<PropertyInfo> pros = t.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
            Dictionary<string, PropertyInfo> dicPros = new Dictionary<string, PropertyInfo>();
            pros.ForEach(i =>
            {
                if (pNames.Contains(i.Name))
                {
                    dicPros.Add(i.Name, i);
                }
            });
            foreach (var dicItem in dicPros)
            {
                object newValue = dicItem.Value.GetValue(model, null);
                foreach (T modify in listModifies)
                {
                    dicItem.Value.SetValue(modify, newValue);
                }
            }
            return SaveChanges();
        }

        #endregion

        #region 4.0根据条件查询一条记录

        /// <summary>
        /// 根据条件查询一条记录
        /// </summary>
        /// <param name="whereLambda">搜索条件</param>
        /// <returns>实体对象</returns>
        public T FindEntity(Expression<Func<T, bool>> whereLambda)
        {
            try
            {
                return db.Set<T>().Where(whereLambda).FirstOrDefault();
            }
            catch (Exception)
            {
                return new T();
            }
        }

        #endregion

        #region 4.1查询所有记录

        /// <summary>
        /// 查询所有记录
        /// </summary>
        /// <param name="topNum">取前几条数据,默认不填(取所有)</param>
        /// <returns>实体集合</returns>
        public List<T> FindList(int topNum = -1)
        {
            try
            {
                if (topNum != -1)
                {
                    return db.Set<T>().Take(topNum).ToList();
                }
                return db.Set<T>().ToList();
            }
            catch (Exception)
            {
                return new List<T>();
            }
        }

        #endregion

        #region 4.2查询多条记录

        /// <summary>
        /// 查询多条记录
        /// </summary>
        /// <param name="whereLambda">搜索条件</param>
        /// <param name="topNum">取前几条数据,默认不填</param>
        /// <returns>实体集合</returns>
        public List<T> FindList(Expression<Func<T, bool>> whereLambda, int topNum = -1)
        {
            try
            {
                if (topNum != -1)
                {
                    return db.Set<T>().Where(whereLambda).Take(topNum).ToList();
                }
                return db.Set<T>().Where(whereLambda).ToList();
            }
            catch (Exception)
            {
                return new List<T>();
            }
        }

        #endregion

        #region 4.3查询多条记录并排序(默认正序)

        /// <summary>
        /// 查询多条记录并排序(默认正序)
        /// </summary>
        /// <typeparam name="TKey">排序类型  可以不写</typeparam>
        /// <param name="whereLambda">搜索条件</param>
        /// <param name="orderLambda">排序条件</param>
        /// <param name="isAsc">是否正序  True默认正序</param>
        /// <returns>实体集合</returns>
        public List<T> FindList<TKey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, bool isAsc = true)
        {
            try
            {
                if (isAsc)
                {
                    return db.Set<T>().Where(whereLambda).OrderBy(orderLambda).ToList();
                }
                return db.Set<T>().Where(whereLambda).OrderByDescending(orderLambda).ToList();
            }
            catch (Exception)
            {
                return new List<T>();
            }
        }

        #endregion

        #region 4.4查询多条记录分页并排序(默认正序)

        /// <summary>
        /// 查询多条记录分页并排序(默认正序)
        /// </summary>
        /// <typeparam name="TKey">排序类型  可以不写</typeparam>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="whereLambda">搜索条件</param>
        /// <param name="orderLambda">排序条件</param>
        /// <param name="isAsc">是否正序  True默认正序</param>
        /// <returns>实体集合</returns>
        public List<T> FindList<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, bool isAsc = true)
        {
            try
            {
                if (isAsc)
                {
                    return db.Set<T>().Where(whereLambda).OrderBy(orderLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                }
                return db.Set<T>().Where(whereLambda).OrderByDescending(orderLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            catch (Exception)
            {
                return new List<T>();
            }
        }

        #endregion

        #region 4.5查询多条记录分页并排序并返回总行数(默认正序)

        /// <summary>
        /// 查询多条记录分页并排序(默认正序)
        /// </summary>
        /// <typeparam name="TKey">排序类型  可以不写</typeparam>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="whereLambda">搜索条件</param>
        /// <param name="orderLambda">排序条件</param>
        /// <param name="totalCount">总条数</param>
        /// <param name="isAsc">是否正序  True默认正序</param>
        /// <returns>实体集合</returns>
        public List<T> FindList<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, out int totalCount, bool isAsc = true)
        {
            try
            {
                totalCount = db.Set<T>().Where(whereLambda).Count();
                if (isAsc)
                {
                    return db.Set<T>().Where(whereLambda).OrderBy(orderLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                }
                return db.Set<T>().Where(whereLambda).OrderByDescending(orderLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            }
            catch (Exception)
            {
                totalCount = 0;
                return new List<T>();
            }
        }

        #endregion

        #region 5.0执行sql语句 并返回集合

        /// <summary>
        /// 执行sql语句 并返回集合
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="parameters">SqlParameter参数集合</param>
        /// <returns>集合</returns>
        public List<T> ExecuteSql(string sql, params object[] parameters)
        {
            try
            {
                return db.Database.SqlQuery<T>(sql, parameters).ToList();
            }
            catch (Exception)
            {
                return new List<T>();
            }
        }

        #endregion

        #region 5.1执行sql语句 并返回集合+结果

        /// <summary>
        /// 执行sql语句 并返回集合+结果
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="parameters">SqlParameter参数集合</param>
        /// <returns>集合</returns>
        public List<T> ExecuteSql(string sql, ref int outResult, SqlParameter outParams, params object[] parameters)
        {
            try
            {
                List<T> ls = db.Database.SqlQuery<T>(sql, outParams, parameters).ToList();
                outResult = (int)outParams.Value;
                return ls;
            }
            catch (Exception)
            {
                return new List<T>();
            }
        }

        #endregion

        #region 5.2执行DDL/DML命令

        /// <summary>
        /// 执行DDL/DML命令
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="parameters">SqlParameter参数集合</param>
        /// <returns>结果</returns>
        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return db.Database.ExecuteSqlCommand(sql, parameters);
        }

        #endregion
    }
}