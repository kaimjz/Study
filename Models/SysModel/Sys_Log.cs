using System; 
using System.ComponentModel.DataAnnotations;

namespace Models
{
    /// <summary>
    /// 日志表
    /// </summary>
    public class Sys_Log
    {
        /// <summary>
        /// 编号
        /// </summary>       
        [PrimaryKey]
        public Guid ID { get; set; }

        /// <summary>
        /// FK Sys_User
        /// </summary>        
        public Guid UserID { get; set; }

        /// <summary>
        /// 实际业务  枚举
        /// </summary>        
        public string LogType { get; set; }

        /// <summary>
        /// 操作页面ID
        /// </summary>        
        public Guid LogModelID { get; set; }

        /// <summary>
        /// 操作内容
        /// </summary>        
        public string LogContent { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>        
        public DateTime CreateDate { get; set; }
    }
}    
	