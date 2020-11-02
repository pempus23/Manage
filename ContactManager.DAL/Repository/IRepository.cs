using System;
using System.Collections.Generic;

namespace ContactManager.DAL.Repository
{
    public interface IRepository<T> : IDisposable
    {
        int Add(T entity);
        int Save(T entity);
        T GetOne(int? id);
        List<T> GetAll();
        int Delete(int id);
    }
}
