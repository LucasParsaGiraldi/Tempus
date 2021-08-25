using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Sistema_Tempus
{
    public class ClienteFactory<T> : IDisposable where T : class
    {
        //private readonly string _entitySetName;
        //private readonly string _keyName;

        private Data _context;
        public Data Context
        {
            get
            {
                if (_context == null)
                    _context = new Data();

                return _context;
            }
        }

        private DbSet<T> _objectSet;
        public DbSet<T> ObjectSet
        {
            get
            {
                if (_objectSet == null)
                    _objectSet = Context.Set<T>();

                return _objectSet;
            }
        }

        public ClienteFactory()
        {

        }

        public virtual void Save(T obj)
        {
            this.ObjectSet.Add(obj);
            Context.SaveChanges();
        }

        public void Delete(T obj)
        {
            this.ObjectSet.Remove(obj);
            Context.SaveChanges();
        }

        public void Update(T obj)
        {
            this.Context.Entry(obj).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public IQueryable<T> SelectAll()
        {
            return this.ObjectSet;
        }

        public IEnumerable<T> GetAll()
        {
            return this.ObjectSet;
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return this.ObjectSet.Where(predicate);
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}