using FaceLessBook.WebForms.IocContainer;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject.Web;

[assembly: WebActivator.PreApplicationStartMethod(typeof(NinjectWeb), "Start")]

namespace FaceLessBook.WebForms.IocContainer
{
    public static class NinjectWeb 
    {
        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
        }
    }
}
