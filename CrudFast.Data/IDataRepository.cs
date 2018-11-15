using System;
using System.Collections.Generic;

namespace CrudFast.Data
{
    public interface IDataRepository { }

    public interface IDataRepository<T> : IDataRepository, IDisposable
        where T : class, new()
    {
        T Add(T entity);
        T Update(T entity);
        void Delete(dynamic id);
        void Delete(T entity);
        IEnumerable<T> Get();
        T Get(dynamic id);
    }
}
