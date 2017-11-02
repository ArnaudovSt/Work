[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(FoodApp.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(FoodApp.Web.App_Start.NinjectWebCommon), "Stop")]

namespace FoodApp.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Extensions.Conventions;
    using FoodApp.Services.Data;
    using FoodApp.Services.Common.TimeProvider;
    using System.Data.Entity;
    using FoodApp.Data;
    using FoodApp.Data.ContextWrapper;
    using FoodApp.Data.UnitOfWork;
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
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
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
            kernel.Bind(x =>
            {
                x.FromThisAssembly()
                    .SelectAllClasses()
                    .BindDefaultInterface();
            });

            kernel.Bind(x =>
            {
                x.FromAssemblyContaining(typeof(IFoodService))
                    .SelectAllClasses()
                    .BindDefaultInterface();
            });

            kernel.Bind<TimeProvider>().ToSelf().InSingletonScope();
            kernel.Bind<DefaultTimeProvider>().ToSelf().InSingletonScope();

            kernel.Bind<DbContext>().To<FoodDbContext>().InRequestScope();
            kernel.Bind(typeof(IContextWrapper<>)).To(typeof(ContextWrapper<>)).InRequestScope();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
        }        
    }
}
