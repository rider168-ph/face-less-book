using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using FaceLessBook.Domain.Contracts.Data;

namespace FaceLessBook.Infrastructure.Data.SqlServer.Repositories
{
    /// <summary>
    /// The EntityFramework dependent, generic repository for data access
    /// </summary>
    /// <typeparam name="T">Type of entity for this Repository</typeparam>
    public class EfRepository<T> : IRepository<T> where T : class
    {
        protected DbContext DatabaseContext { get; set; }

        protected DbSet<T> DatabaseSet { get; set; }

        public EfRepository(DbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext");
            DatabaseContext = dbContext;
            DatabaseSet = DatabaseContext.Set<T>();
        }

        #region IRepository implementation

        public IQueryable<T> FindWhere(Expression<Func<T, bool>> predicate)
        {
            return DatabaseSet.Where(predicate);
        }

        public T GetById(int id)
        {
            return DatabaseSet.Find(id);
        }

        public void Add(T entity)
        {
            DbEntityEntry dbEntityEntry = DatabaseContext.Entry(entity);

            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DatabaseSet.Add(entity);
            }
        }

        public void Update(T entity)
        {
            DbEntityEntry dbEntityEntry = DatabaseContext.Entry(entity);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                DatabaseSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = DatabaseContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DatabaseSet.Attach(entity);
                DatabaseSet.Remove(entity);
            }
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return; // not found; assume already deleted.
            Delete(entity);
        }

        #endregion
    }
}
