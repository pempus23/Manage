using ContactManager.DAL.EF;
using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace ContactManager.DAL.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : EntityBase, new()
    {
        protected readonly DbSet<T> _table;
        private readonly ContactManagerContext _db;
        protected ContactManagerContext Context => _db;
        public BaseRepository()
        {
            _db = new ContactManagerContext();
            _table = _db.Set<T>();
        }
        public int Add(T entity)
        {
            _db.Entry(entity).State = EntityState.Added;
            return SaveChanges();
        }

        public int Delete(int id)
        {
            Person ann = _db.People.FirstOrDefault(row => row.Id == id);
            Context.People.Remove(ann);
            return SaveChanges();
        }

        public void Dispose()
        {
            _db?.Dispose();
        }

        public virtual List<T> GetAll() => _table.ToList();

        public T GetOne(int? id) => _table.Find(id);

        public int Save(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }
        internal int SaveChanges()
        {
            try
            {
                return _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }
            catch (DbUpdateException ex)
            {
                throw;
            }
            catch (CommitFailedException ex)
            {

                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
