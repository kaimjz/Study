using System;
using System.Collections.Generic;

namespace Models
{
    /// <summary>
    /// 角色表
    /// </summary>
    public class Sys_Role
    {
        [PrimaryKey]
        public Guid ID { get; set; }

        public string Name { get; set; }
        public int RoleLevel { get; set; }
        public int Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public virtual List<Sys_User> UserList { get; set; }
    }
}