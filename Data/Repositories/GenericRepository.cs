using Data.Models;
using Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly LinieAutobusoweContext _context;

        public GenericRepository(LinieAutobusoweContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            T entities = _context.Set<T>().Find(entity);
            _context.Set<T>().Remove(entities);
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>().AsQueryable();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }
    }
}
