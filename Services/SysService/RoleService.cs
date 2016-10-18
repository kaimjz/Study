using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Services
{
    /// <summary>
    /// 角色
    /// </summary>
    public static class RoleService
    {
        private static IRepository<Sys_Role> DBContext = new RepositoryFactory<Sys_Role>().DBContext;

        #region 查询角色集合

        /// <summary>
        /// 查询角色集合
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public static List<Sys_Role> FindRoleList(Expression<Func<Sys_Role, bool>> where = null)
        {
            if (where != null)
            {
                //return new RepositoryFactory().DB.Sys_Role.;
                return DBContext.FindList(where);
            }
            return DBContext.FindList();
        }

        #endregion
    }
}