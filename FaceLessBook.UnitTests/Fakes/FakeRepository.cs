using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FaceLessBook.Domain.Contracts;
using FaceLessBook.Domain.Contracts.Data;

namespace FaceLessBook.UnitTests.Fakes
{
    public class FakeRepository<T> : IRepository<T> where T: class, IEntity
    {
        protected readonly HashSet<T> _set;
        protected readonly IQueryable<T> _queryableSet;   

        public FakeRepository()
            : this(Enumerable.Empty<T>())
        {
        }

        public FakeRepository(IEnumerable<T> entities)
        {
            _set = new HashSet<T>();
            foreach (var entity in entities)
            {
                _set.Add(entity);
            }

            _queryableSet = _set.AsQueryable();
        }

        public IQueryable<T> FindWhere(Expression<Func<T, bool>> predicate)
        {
            return _queryableSet.Where(predicate);
        }

        public T GetById(int id)
        {
            return _queryableSet.Single(e => e.Id == id);
        }

        public void Add(T entity)
        {
            _set.Add(entity);
        }

        public void Update(T entity)
        {
            var modifiedHashSet = _set.FirstOrDefault(x => x.Id == entity.Id);
        }

        public void Delete(T entity)
        {
            _set.Remove(entity);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);

            if(entity != null)
                Delete(entity);
        }
    }
}
