using BLL.Factories;
using BLL.Service;
using DAL;
using DAL.Repositories;
using Domain;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Web.App_Start.NinjectWebCommon), "Stop")]

namespace Web.App_Start
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
            kernel.Bind<ApplicationDbContext>().To<ApplicationDbContext>().InRequestScope();

            kernel.Bind<EFRepository<Author>>().To<EFRepository<Author>>().InRequestScope();
            kernel.Bind<EFRepository<Book>>().To<EFRepository<Book>>().InRequestScope();
            kernel.Bind<EFRepository<Publisher>>().To<EFRepository<Publisher>>().InRequestScope();
            kernel.Bind<EFRepository<AuthorBook>>().To<EFRepository<AuthorBook>>().InRequestScope();
            kernel.Bind<EFRepository<Comment>>().To<EFRepository<Comment>>().InRequestScope();

            kernel.Bind<AuthorFactory>().To<AuthorFactory>().InRequestScope();

            kernel.Bind<AuthorService>().To<AuthorService>().InRequestScope();

        }
    }
}
