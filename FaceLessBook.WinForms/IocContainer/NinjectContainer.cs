using Ninject;
using Ninject.Modules;

namespace FaceLessBook.WinForms.IocContainer
{
    public class NinjectContainer
    {
        private static IKernel _ninjectKernel;

        public static void Wire(INinjectModule module)
        {
            _ninjectKernel = new StandardKernel(module);
        }

        public static T Resolve<T>()
        {
            return _ninjectKernel.Get<T>();
        }
    }
}
