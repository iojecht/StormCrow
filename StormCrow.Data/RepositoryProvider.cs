using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace StormCrow.Data
{
    public class RepositoryProvider : IRepositoryProvider
    {
        public DbContext DbContext { get; set; }
        private RepositoryFactory _repositoryFactories { get; set; }
        protected Dictionary<Type, object> Repositories { get; private set; }

        public RepositoryProvider(RepositoryFactory repositoryFactories)
        {
            _repositoryFactories = repositoryFactories;
            Repositories = new Dictionary<Type, object>();
        }

        public IRepository<T> GetRepositoryForEntityType<T>() where T : class
        {
            return GetRepository<IRepository<T>>(
                _repositoryFactories.GetRepositoryFactoryForEntityType<T>());
        }

        public virtual T GetRepository<T>(Func<DbContext, object> factory = null) where T : class
        {
            object repositoryObject;
            Repositories.TryGetValue(typeof(T), out repositoryObject);
            if (repositoryObject != null)
            {
                return repositoryObject as T;
            }

            return MakeRepository<T>(factory, DbContext);
        }

        public virtual T MakeRepository<T>(Func<DbContext, object> factory, DbContext dbContext)
        {
            var f = factory ?? _repositoryFactories.GetRepositoryFactory<T>();
            if (f == null)
            {
                throw new NotImplementedException("No factory for repository type");
            }
            var repo = (T)f(dbContext);
            Repositories[typeof (T)] = repo;
            return repo;
        }

        public void SetRepository<T>(T repository)
        {
            Repositories[typeof (T)] = repository;
        }
    }
}