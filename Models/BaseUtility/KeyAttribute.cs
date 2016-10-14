using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 表示一个或多个用于唯一标识实体的属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class PrimaryKeyAttribute : Attribute
    {
        /// <summary>
        /// 初始化属性构造函数
        /// </summary>
        public PrimaryKeyAttribute() { }
    }

    // 摘要: 
    //     表示关系中用作外键的属性。
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class ForeignKeyAttribute : Attribute
    {
        // 参数: 
        //   name:相关联外键的名称。
        public ForeignKeyAttribute(string name) { this.Name = name; }

        // 摘要: 
        //     获取与此外键关联的名称。
        //
        // 返回结果: 
        //     相关联外键的名称。
        public string Name { get; set; }
    }
}
