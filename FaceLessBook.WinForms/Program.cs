using System;
using System.Windows.Forms;
//using Microsoft.Practices.Unity;
using FaceLessBook.WinForms.IocContainer;

namespace FaceLessBook.WinForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            NinjectContainer.Wire(new ApplicationModule());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //IUnityContainer container = new UnityContainer();

            //// Infrastructure - Data
            //// control lifecycle using Singleton - one instance
            //container.RegisterType<RepositoryFactories, RepositoryFactories>(new ContainerControlledLifetimeManager());

            //container.RegisterType<IRepositoryProvider, RepositoryProvider>();
            //container.RegisterType<IUnitOfWork, FaceLessBookUnitOfWork>();

            //// Domain - Commands
            //container.RegisterType<IFriendCommandFactory, FriendCommandFactory>();

            //// Infrastructure - Services
            //container.RegisterType<IEMailSender, EMailSender>();

            //// Infrastructure - Logger
            //container.RegisterType<ILogger, DebugLogger>(); //("DebugLogger");
            ////container.RegisterType<ILogger, DatabaseLogger>("DBLogger");

            //Application.Run(container.Resolve<MainForm>());

            Application.Run(NinjectContainer.Resolve<MainForm>());
        }
    }
}
