using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Models
{
    public partial class DataContext : DbContext
    {
        #region 上下文

        public DataContext()
            : base("ConnectionString")
        {
            Database.SetInitializer<DataContext>(null);
            //Database.SetInitializer<DataContext>(new DropCreateDatabaseIfModelChanges<DataContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//移除复数表名的契约
            modelBuilder.Entity<Sys_RoleOperating>().HasKey(t => new { t.RoleID, t.OperatingID });
            base.OnModelCreating(modelBuilder);
            /*

                可以删除的公约有：

                Namespace:System.Data.Entity.ModelConfiguration.Conventions.Edm

                • AssociationInverseDiscoveryConvention

                寻找导航上互相引用的类的属性，并将它们配置为逆属性的相同的关系。

                • ComplexTypeDiscoveryConvention

                寻找有没有主键的类型，并将它们配置为复杂类型。

                • DeclaredPropertyOrderingConvention

                确保每个实体的主要关键属性优先于其他属性。

                • ForeignKeyAssociationMultiplicityConvention

                配置是必需的还是可选的关系基于为空性外键属性，如果包含在类定义中。

                • IdKeyDiscoveryConvention

                查找名为 Id 或 <TypeName> Id 的属性，并将他们配置作为主键。

                • NavigationPropertyNameForeignKeyDiscoveryConvention

                使用外键关系，使用 <NavigationProperty> <PrimaryKeyProperty> 模式作为属性的外观。

                • OneToManyCascadeDeleteConvention

                交换机上层叠删除，所需的关系。

                • OneToOneConstraintIntroductionConvention

                将配置为一个： 一个关系的外键的主键。

                • PluralizingEntitySetNameConvention

                配置为多元化的类型名称的实体数据模型中的实体集的名称。

                • PrimaryKeyNameForeignKeyDiscoveryConvention

                使用外键关系，使用 <PrimaryKeyProperty> 模式作为属性的外观。

                • PropertyMaxLengthConvention

                配置所有的字符串和字节 [] 属性，默认情况下具有最大长度。

                • StoreGeneratedIdentityKeyConvention

                配置默认情况下将标识所有整数的主键。

                • TypeNameForeignKeyDiscoveryConvention

                使用外键关系，使用 <PrincipalTypeName> <PrimaryKeyProperty> 模式作为属性的外观。

             */
        }

        #endregion

        #region SysModel

        public DbSet<Sys_Log> Sys_Log { get; set; }
        public DbSet<Sys_Operating> Sys_Operating { get; set; }
        public DbSet<Sys_Role> Sys_Role { get; set; }
        public DbSet<Sys_RoleOperating> Sys_RoleOperating { get; set; }
        public DbSet<Sys_User> Sys_User { get; set; }

        #endregion
    }
}