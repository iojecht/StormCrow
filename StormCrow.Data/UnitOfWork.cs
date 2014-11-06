using System;
using StormCrow.Data.Contract;
using StormCrow.Domain;

namespace StormCrow.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private StormCrowDbContext DbContext { get; set; }

        public UnitOfWork(IRepositoryProvider repositoryProvider)
        {
            CreateDbContext();

            repositoryProvider.DbContext = DbContext;
            RepositoryProvider = repositoryProvider;
        }

        public IRepository<Organization> Organizations { get { return GetStandardRepo<Organization>(); } }
        public IRepository<Product> Products { get { return GetStandardRepo<Product>(); } }
        public IRepository<Pallet> Pallets { get { return GetStandardRepo<Pallet>(); } }
        public IItemRepository Items { get { return GetRepo<IItemRepository>(); } }

        protected void CreateDbContext()
        {
            DbContext = new StormCrowDbContext();
            DbContext.Configuration.ProxyCreationEnabled = false;
            DbContext.Configuration.LazyLoadingEnabled = false;
            DbContext.Configuration.ValidateOnSaveEnabled = false;
        }

        protected IRepositoryProvider RepositoryProvider { get; set; }

        private IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}