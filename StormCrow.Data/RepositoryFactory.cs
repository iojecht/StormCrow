using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using StormCrow.Data.Contract;

namespace StormCrow.Data
{
    public class RepositoryFactory
    {
        private IDictionary<Type, Func<DbContext, object>> _repositoryFactories;

        // Factories - Must modify if adding new custom repository
        public IDictionary<Type,Func<DbContext,Object>> GetStormCrowFactories()
        {
            return new Dictionary<Type, Func<DbContext, object>>()
            {
                {typeof (IItemRepository), dbContext => new ItemRepository(dbContext)}
            };
        }

        public RepositoryFactory()
        {
            _repositoryFactories = GetStormCrowFactories();
        }

        public Func<DbContext, object> GetRepositoryFactory<T>()
        {
            Func<DbContext, object> factory;
            _repositoryFactories.TryGetValue(typeof (T), out factory);
            return factory;
        }

        public Func<DbContext, object> GetRepositoryFactoryForEntityType<T>() where T : class
        {
            return GetRepositoryFactory<T>() ?? DefaultEntityRepositoryFactory<T>();
        }

        protected virtual Func<DbContext, object> DefaultEntityRepositoryFactory<T>() where T : class 
        {
            return dbContext => new GenericRepository<T>(dbContext);
        }
    }
}