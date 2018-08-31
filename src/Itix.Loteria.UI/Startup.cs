using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Itix.Agenda.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Itix.Agenda.Core.Infra;
using Itix.Agenda.Core.Infra.IocContainer;

namespace Itix.Agenda
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            AppConfig.Configuration = configuration;


            containerRegister = new ContainerRegister();
        }

        public IConfiguration Configuration { get; }

        ContainerRegister containerRegister;


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMvc().AddFeatureFolders();

            containerRegister.ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            containerRegister.Configure(app, env);


            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    
                    template: "{controller=home}/{action=Index}/{id?}");
            });
        }
    }
}
