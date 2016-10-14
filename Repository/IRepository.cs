using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace Repositories
{
    /// <summary>
    /// 定义通用的Repository接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> : IDisposable where T : class, new()
    {
        #region 上下文

        DataContext db { get; set; }

        #endregion

        #region 1.0增加一条记录

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="model">实体类</param>
        /// <returns>int 影响行数</returns>
        int Insert(T model);

        #endregion

        #region 2.0根据条件删除所有记录

        /// <summary>
        /// 根据条件删除所有记录
        /// </summary>
        /// <returns>int 影响行数</returns>
        int Delete();

        #endregion

        #region 2.1删除一条记录

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="model">实体类</param>
        /// <returns>int 影响行数</returns>
        int Delete(T model);

        #endregion

        #region 2.2根据条件删除N条记录

        /// <summary>
        /// 根据条件删除N条记录
        /// </summary>
        /// <param name="whereLambda">删除条件</param>
        /// <returns>int 影响行数</returns>
        int Delete(Expression<Func<T, bool>> whereLambda);

        #endregion

        #region 3.0修改一条记录的某些字段

        /// <summary>
        /// 修改一条记录的某些字段
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="model">实体类</param>
        /// <param name="pNames">具体修改的字段</param>
        /// <returns>int 影响行数</returns>
        int Modidy(T model, params string[] pNames);

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
        int Modidy(T model, Expression<Func<T, bool>> whereLambda, params string[] pNames);

        #endregion

        #region 4.0根据条件查询一条记录

        /// <summary>
        /// 根据条件查询一条记录
        /// </summary>
        /// <param name="whereLambda">搜索条件</param>
        /// <returns>实体对象</returns>
        T FindEntity(Expression<Func<T, bool>> whereLambda);

        #endregion

        #region 4.1查询多条记录

        /// <summary>
        /// 查询多条记录
        /// </summary>
        /// <param name="topNum">取前几条数据,默认不填(取所有)</param>
        /// <returns>实体集合</returns>
        List<T> FindList(int topNum = -1);

        #endregion

        #region 4.2查询多条记录

        /// <summary>
        /// 查询多条记录
        /// </summary>
        /// <param name="whereLambda">搜索条件</param>
        /// <param name="topNum">取前几条数据,默认不填</param>
        /// <returns>实体集合</returns>
        List<T> FindList(Expression<Func<T, bool>> whereLambda, int topNum = -1);

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
        List<T> FindList<TKey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, bool isAsc = true);

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
        List<T> FindList<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, bool isAsc = true);

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
        List<T> FindList<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda, out int totalCount, bool isAsc = true);

        #endregion

        #region 5.0执行sql语句 并返回集合

        /// <summary>
        /// 执行sql语句 并返回集合
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="parameters">SqlParameter参数集合</param>
        /// <returns>集合</returns>
        List<T> ExecuteSql(string sql, params object[] parameters);

        #endregion

        #region 5.1执行sql语句 并返回集合+结果

        /// <summary>
        /// 执行sql语句 并返回集合+结果
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="parameters">SqlParameter参数集合</param>
        /// <returns>集合</returns>
        List<T> ExecuteSql(string sql, ref int outResult, SqlParameter outParams, params object[] parameters);

        #endregion

        #region 5.2执行DDL/DML命令

        /// <summary>
        /// 执行DDL/DML命令
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="parameters">SqlParameter参数集合</param>
        /// <returns>结果</returns>
        int ExecuteSqlCommand(string sql, params object[] parameters);

        #endregion
    }
}