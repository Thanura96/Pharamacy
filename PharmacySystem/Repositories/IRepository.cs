using System.Collections.Generic;

namespace PharmacySystem.Repositories
{
    /// <summary>
    /// Generic repository abstraction demonstrating interface-based data access.
    /// </summary>
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(string id);
        T GetById(string id);
        List<T> GetAll();
    }
}
