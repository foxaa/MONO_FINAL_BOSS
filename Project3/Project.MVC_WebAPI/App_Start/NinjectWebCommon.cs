[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Project.MVC_WebAPI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Project.MVC_WebAPI.App_Start.NinjectWebCommon), "Stop")]

namespace Project.MVC_WebAPI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Project.Model.Common;
    using Project.Service.Common;
    using Service;
    using Repository.Common;
    using Repository;
    using Model;
    using DAL;
    using System.Linq;
    using System.Web.Http;

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
            //var kernel = new StandardKernel();
            //var kernel = new StandardKernel(new NinjectSettings() { LoadExtensions = false });
            var settings = new NinjectSettings();
            settings.LoadExtensions = true;
            settings.ExtensionSearchPatterns = settings.ExtensionSearchPatterns.Union(new string[] { "Project.*.dll" }).ToArray();
            var kernel = new StandardKernel(settings);

            try
            {
                //kernel.Load("Project*.dll");
                //kernel.Load(AppDomain.CurrentDomain.GetAssemblies());
                /*kernel.Load("Project.DAL.data.dll");
                kernel.Load("Project.DAL.service.dll");
                kernel.Load("Project.Model.data.dll");
                kernel.Load("Project.Model.service.dll");
                kernel.Load("Project.Repository.data.dll");
                kernel.Load("Project.Repository.service.dll");
                kernel.Load("Project.Service.data.dll");
                kernel.Load("Project.Service.service.dll");*/
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new Ninject.Web.WebApi.NinjectDependencyResolver(kernel);

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
        }        
    }
}
