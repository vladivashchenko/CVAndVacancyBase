[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DesignStudio.WebAPI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(DesignStudio.WebAPI.App_Start.NinjectWebCommon), "Stop")]

namespace DesignStudio.WebAPI.App_Start
{
    using System;
    using System.Web;
    using System.Web.Http;
    using CVAndVacancyBase.App_Start;
    using CVAndVacancyBase.BLL.DTO;
    using CVAndVacancyBase.BLL.Infrastructure;
    using CVAndVacancyBase.BLL.Interfaces;
    using CVAndVacancyBase.BLL.Services;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Modules;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        public static IKernel CreateKernel()
        {

            var modules = new INinjectModule[] { new ServiceModule("CVandVacancyBase") };
            var kernel = new StandardKernel(modules);
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);

                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }


        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IService<VacancyDTO>>().To<VacancyService>();
            kernel.Bind<IService<CVDTO>>().To<CVService>();
            kernel.Bind<IUserService>().To<UserService>();
        }
    }
}