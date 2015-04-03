using System;
using System.Linq;
using System.Linq.Expressions;

namespace FaceLessBook.Domain.Contracts.Data
{
    /// <summary>
    /// Generic repository
    /// </summary>
    /// <typeparam name="T">Entity or Domain Object</typeparam>
    public interface IRepository<T> where T : class
    {
        // works with ExpressionTree
        // both IEnumerable and IQueryable implements lazy load (deferred execution)
        // if this will be iterated in a for each loop this will have roundtrip query to 
        // to the database. To avoid this roundtrip, it should have the ToList() before iteration
        // NOTE: Make sure that the where statement columns should have indexes
        IQueryable<T> FindWhere(Expression<Func<T, bool>> predicate);
        
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
    }
}
