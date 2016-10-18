using Models;
using System.Runtime.Remoting.Messaging;

namespace Repositories
{
    /// <summary>
    /// 通用的Repository工厂
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class RepositoryFactory<T> where T : class ,new()
    {
        /// <summary>
        /// 定义通用的Repository
        /// </summary>
        /// <returns></returns>
        public IRepository<T> DBContext
        {
            get
            {
                return new Repository<T>();
            }
        }
    }

    public partial class RepositoryFactory
    {
        /// <summary>
        /// 定义通用的DBContext
        /// </summary>
        public DataContext DB
        {
            get
            {
                DataContext db = (DataContext)CallContext.GetData("DataContext");
                if (db == null)
                {
                    db = new DataContext();
                    //延迟加载  true开启
                    db.Configuration.LazyLoadingEnabled = true;
                    CallContext.SetData("DataContext", db);
                }
                return db;
            }
        }
    }
}