using System;

namespace Models
{
    /// <summary>
    /// 权限页面表
    /// </summary>
    public class Sys_Operating
    {
        /// <summary>
        /// 编号
        /// </summary>
        [PrimaryKey]
        public Guid ID { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>
        public Guid ParentID { get; set; }

        /// <summary>
        /// 页面名
        /// </summary>
        public string OpName { get; set; }

        /// <summary>
        /// 等级 数值越小   级别越高
        /// </summary>
        public int OpLevel { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 排序   数值越小   越靠前
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 显隐  1显示，0隐藏
        /// </summary>
        public int IsPublic { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}