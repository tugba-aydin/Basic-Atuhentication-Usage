using System.Collections.Generic;

namespace BasicAuthenticationExample.Data
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void SaveAll();
        void Delete(int id);
        List<T> GetAll();
        T GetById(int id);
        void Update(T entity);
    }
}
