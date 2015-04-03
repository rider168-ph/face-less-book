using FaceLessBook.Domain.Contracts.Data;
using FaceLessBook.Infrastructure.Data.SqlServer;
using FaceLessBook.Infrastructure.Data.SqlServer.Helpers;
using FaceLessBook.Infrastructure.Data.SqlServer.Repositories;
using TechTalk.SpecFlow;

namespace FaceLessBook.AcceptanceTests
{
    public abstract class SqlServerDataContextBase
    {
        // Fields needed for the Commands
        // These will be injected using an IoC container when implemented on the UI - MVP
        protected IUnitOfWork UnitOfWork;
        private IRepositoryProvider _repositoryProvider;
        private RepositoryFactories _repositoryFactories;

        [BeforeScenario]
        protected virtual void Init()
        {
            // initial implementation
            _repositoryFactories = new RepositoryFactories();
            _repositoryProvider = new RepositoryProvider(_repositoryFactories)
            {
                DbContext = new SqlServerDbContext()
            };

            UnitOfWork = new SqlServerUnitOfWork(_repositoryProvider);

            // specific command factory can be added by overridng and adding the 
            // needed initialization
        }

        [AfterScenario]
        protected virtual void CleanUp()
        {

        }

    }
}
