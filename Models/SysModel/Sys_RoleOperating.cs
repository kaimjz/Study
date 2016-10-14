using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    /// <summary>
    /// 角色权限外键表
    /// </summary>
        
    public class Sys_RoleOperating
    {
        /// <summary>
        /// PK Sys_Role
        /// </summary>        
        [PrimaryKey]
        public string RoleID { get; set; }
        /// <summary>
        /// FK Sys_Operating
        /// </summary>        
        [PrimaryKey]
        public string OperatingID { get; set; }

    }
}