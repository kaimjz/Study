using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    /// <summary>
    /// 用户表
    /// </summary>
    public partial class Sys_User
    {
        [PrimaryKey]
        public Guid ID { get; set; }

        public string LoginName { get; set; }
        public string LoginPwd { get; set; }
        public string UserName { get; set; }

        [Required]
        public Guid? RoleID { get; set; }

        public DateTime? CreateDate { get; set; }
        public int Status { get; set; }

        [ForeignKey("RoleID")]
        public virtual Sys_Role Role { get; set; }
    }
}