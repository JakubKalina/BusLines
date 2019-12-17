using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        IQueryable<T> Get();
        T GetById(int id);
        void Delete(T entity);
        void Update(T entity);
        void Create(T entity);
        void Save();
    }
}
