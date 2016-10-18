using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Services
{
    /// <summary>
    /// 用户
    /// </summary>
    public static class UserService
    {
        private static IRepository<Sys_User> DBContext = new RepositoryFactory<Sys_User>().DBContext;

        #region 添加用户

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int InsertUser(Sys_User model)
        {
            return DBContext.Insert(model);
        }

        #endregion

        #region 删除用户

        public static int Delete(string id)
        {
            Sys_User model = new Sys_User()
            {
                ID = new Guid(id)
            };
            return DBContext.Delete(model);
        }

        #endregion

        #region 根据id 查询实体

        /// <summary>
        /// 根据id 查询实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Sys_User FindEntityByID(string id)
        {
            return DBContext.FindEntity(p => p.ID.ToString() == id);
        }

        #endregion

        #region 修改实体

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <param name="pNames"></param>
        /// <returns></returns>
        public static int ModidyEntity(Sys_User model, params string[] pNames)
        {
            return DBContext.Modidy(model, pNames);
        }

        #endregion

        #region 查询所有用户

        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        public static List<Sys_User> FindUserList(Expression<Func<Sys_User, bool>> whereLambda = null)
        {
            if (whereLambda != null)
            {
                return DBContext.FindList(whereLambda);
            }
            return DBContext.FindList();
        }

        #endregion
    }
}