using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;

namespace StormCrow.Data
{
    public class RepositoryFactory
    {
        private readonly IDictionary<Type, Func<DbContext, object>> _repositoryFactories;

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