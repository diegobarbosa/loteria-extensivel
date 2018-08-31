using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

using SimpleInjector;
using SimpleInjector.Lifestyles;
using SimpleInjector.Integration.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Reflection;

namespace Itix.Agenda.Core.Infra.IocContainer
{
    public class ContainerRegister
    {
        Container container;

        public ContainerRegister()
        {
            container = new Container();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            StaticContainer.Container = new SimpleInjectorContainer(container);

            //container.Options.PropertySelectionBehavior =
            //  new ImportAttributePropertySelectionBehavior();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(
                new SimpleInjectorControllerActivator(container));
            services.AddSingleton<IViewComponentActivator>(
                new SimpleInjectorViewComponentActivator(container));

            services.EnableSimpleInjectorCrossWiring(container);
            services.UseSimpleInjectorAspNetRequestScoping(container);


        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //InitializeContainer;
            // Add application presentation components:
            container.RegisterMvcControllers(app);
            container.RegisterMvcViewComponents(app);

            // Add application services. For instance:
            //container.Register<IUserService, UserService>(Lifestyle.Scoped);
            RegistrarTodosOsModulos(container);

            container.Register<IContainer>(() => StaticContainer.Container);


            // Allow Simple Injector to resolve services from ASP.NET Core.
            container.AutoCrossWireAspNetComponents(app);

          


            container.Verify();
        }


        static void RegistrarTodosOsModulos(Container container)
        {
            var assemblies = new AssembliesItix();


            var type = typeof(IContainerRegister);
            var types = assemblies.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract);


            foreach (var item in types)
            {
                var containerRegister = (Activator.CreateInstance(item) as IContainerRegister);
                containerRegister.Assemblies = assemblies;

                containerRegister.Register(container);
            }
        }


        //static void DesabilitarWarningsPara(Container container)
        //{
        //    container
        //    .GetRegistration(typeof(BaseController))
        //    .Registration
        //    .SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent,
        //    "É disposado pelo Asp.Net");
        //}
    }
}
