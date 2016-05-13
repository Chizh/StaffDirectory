using System.Configuration;
using System.Web.Http;
using RetailRocket.StaffDirectory.Data;
using RetailRocket.StaffDirectory.Data.Repository;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(RetailRocket.StaffDirectory.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(RetailRocket.StaffDirectory.App_Start.NinjectWebCommon), "Stop")]

namespace RetailRocket.StaffDirectory.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

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

                // Install the Ninject-based IDependencyResolver into the Web API config
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
        /// Load modules and register services.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            RegisterService(kernel, ConfigurationManager.ConnectionStrings["StaffDirectoryConnectionString"].ConnectionString);
        }

        /// <summary>
        /// Load modules and register services.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        /// <param name="connectionString">The connection string to database.</param>
        public static void RegisterService(IKernel kernel, string connectionString)
        {
            kernel.Bind<StaffDirectoryDbDataContext>()
                .ToMethod(
                    c =>
                        new StaffDirectoryDbDataContext(
                            connectionString));
            kernel.Bind<IRepository>().To<SqlRepository>().InRequestScope();
        }
    }
}
