using Models;
using Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System;

namespace Services
{
    /// <summary>
    /// 用户
    /// </summary>
    public static class UserService
    {
        private static IRepository<Sys_User> DBContext = new RepositoryFactory<Sys_User>().DBContext;

        #region 查询所有用户

        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        public static List<Sys_User> FindUserList()
        {
            return DBContext.FindList();
        }

        #endregion

        public static List<Sys_User> FindUserList(Expression<Func<Sys_User,bool>> whereLambda)
        {
            return DBContext.FindList(whereLambda);
        }
    }
}