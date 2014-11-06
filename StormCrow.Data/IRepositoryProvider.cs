using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace StormCrow.Data
{
    public interface IRepositoryProvider
    {
        DbContext DbContext { get; set; }
        IRepository<T> GetRepositoryForEntityType<T>() where T : class;
        T GetRepository<T>(Func<DbContext, object> factory = null) where T : class;
        T MakeRepository<T>(Func<DbContext, object> factory, DbContext dbContext);
        void SetRepository<T>(T repository);
    }
}