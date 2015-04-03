using FaceLessBook.Domain.Commands.Member;
using FaceLessBook.Domain.Contracts.Commands;
using FaceLessBook.Domain.Contracts.Data;
using FaceLessBook.Domain.Contracts.Logger;
using FaceLessBook.Domain.Contracts.Services;
using FaceLessBook.Infrastructure.Data.SqlServer;
using FaceLessBook.Infrastructure.Data.SqlServer.Helpers;
using FaceLessBook.Infrastructure.Data.SqlServer.Repositories;
using FaceLessBook.Infrastructure.Logger;
using FaceLessBook.Infrastructure.Services;
using Ninject.Modules;

namespace FaceLessBook.WinForms.IocContainer
{
    public class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            // Infrastructure - Data (Sql Server)
            Bind<RepositoryFactories>().To<RepositoryFactories>()
                .InSingletonScope();
            Bind<IRepositoryProvider>().To<RepositoryProvider>();
            Bind<IUnitOfWork>().To<SqlServerUnitOfWork>();

            // Domain - Commands
            Bind<IFriendCommandFactory>().To<FriendCommandFactory>();

            // Infrastructure - Services
            Bind<IEMailSender>().To<EMailSender>();

            // Infrastructure - Logger
            Bind<ILogger>().To<DebugLogger>();
        }
    }
}
