using System;
using FaceLessBook.Domain.Contracts.Data;
using FaceLessBook.Domain.Models;
using FaceLessBook.Infrastructure.Data.SqlServer.Helpers;

namespace FaceLessBook.Infrastructure.Data.SqlServer
{
    /// <summary>
    /// The FaceLessBook "Unit of Work"
    ///     1) decouples the repositories from the controllers/presenters
    ///     2) decouples the DbContext and EF from the controllers/presenters
    ///     3) manages the Unit of Work
    /// </summary>
    /// <remarks>
    /// This class implements the "Unit of Work" design pattern that serves as a facade
    /// for querying and saving to the database.
    /// Querying is delegated to "repositories".
    /// Each repository serves as a container dedicated to a particular root entity type
    /// such as User.
    /// A repository typically exposes "Get" methods for querying and will offer add, update,
    /// and, delete methods if those features are supported.
    /// The repositories rely on their parent "Unit of Work" to provide the interface to the
    /// data layer (which is the EF DbContext).
    /// </remarks>
    public class SqlServerUnitOfWork : IUnitOfWork, IDisposable
    {
        private  SqlServerDbContext DataContext { get; set; }
        private  IRepositoryProvider RepoProvider { get; set; }

        // FaceLessBook Repositories
        public IRepository<User> Users {
            get { return GetStandardRepo<User>(); }
        }
        public IFriendRepository Friends {
            get { return GetRepo<IFriendRepository>(); }
        }
        

        public SqlServerUnitOfWork(IRepositoryProvider repositoryProvider)
        {
            CreateDbContext();

            repositoryProvider.DbContext = DataContext;
            RepoProvider = repositoryProvider;
        }

        private void CreateDbContext()
        {
            DataContext = new SqlServerDbContext();

            // Do NOT enable proxied entities, else serialization fails
            DataContext.Configuration.ProxyCreationEnabled = false;

            // Load navigation properties explicitly (avoid serialization trouble)
            DataContext.Configuration.LazyLoadingEnabled = false;

            // Because Web API will perform validation, we don't need/want EF to do so
            DataContext.Configuration.ValidateOnSaveEnabled = false;

            //DataContext.Configuration.AutoDetectChangesEnabled = false;
            // We won't use this performance tweak because we don't need 
            // the extra performance and, when autodetect is false,
            // we'd have to be careful. We're not being that careful.
        }

        /// <summary>
        /// Save pending changes to the database
        /// </summary>
        public void Commit()
        {
            DataContext.SaveChanges();
        }


        private IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepoProvider.GetRepositoryForEntityType<T>();
        }

        private T GetRepo<T>() where T : class
        {
            return RepoProvider.GetRepository<T>();
        }

        #region IDisposable implementation

        //TODO: implement this from the commands or the controller base
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DataContext != null)
                {
                    DataContext.Dispose();
                }
            }
        }

        #endregion
    }
}
