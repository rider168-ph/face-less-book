using System;
using System.Web;
using FaceLessBook.Domain.Commands.Member;
using FaceLessBook.Domain.Contracts.Commands;
using FaceLessBook.Domain.Contracts.Data;
using FaceLessBook.Domain.Contracts.Logger;
using FaceLessBook.Domain.Contracts.Services;

using FaceLessBook.Infrastructure.Data.SqlServer;
using FaceLessBook.Infrastructure.Data.SqlServer.Helpers;
using FaceLessBook.Infrastructure.Data.SqlServer.Repositories;

//using FaceLessBook.Infrastructure.Data.Oracle;
//using FaceLessBook.Infrastructure.Data.Oracle.Helpers;
//using FaceLessBook.Infrastructure.Data.Oracle.Repositories;

using FaceLessBook.Infrastructure.Logger;
using FaceLessBook.Infrastructure.Services;
using FaceLessBook.WebForms.IocContainer;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;

[assembly: WebActivator.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace FaceLessBook.WebForms.IocContainer
{
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            // Infrastructure - Data (SqlServer)
            kernel.Bind<RepositoryFactories>().To<RepositoryFactories>()
                .InSingletonScope();
            kernel.Bind<IRepositoryProvider>().To<RepositoryProvider>();
            kernel.Bind<IUnitOfWork>().To<SqlServerUnitOfWork>();

            // Infrastructure - Data (Oracle)
            //kernel.Bind<RepositoryFactories>().To<RepositoryFactories>()
            //    .InSingletonScope();
            //kernel.Bind<IRepositoryProvider>().To<RepositoryProvider>();
            //kernel.Bind<IUnitOfWork>().To<OracleUnitOfWork>();

            // Domain - Commands
            kernel.Bind<IFriendCommandFactory>().To<FriendCommandFactory>();

            // Infrastructure - Services
            kernel.Bind<IEMailSender>().To<EMailSender>();

            // Infrastructure - Logger
            kernel.Bind<ILogger>().To<DebugLogger>();
        }        
    }
}
