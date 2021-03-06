using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrusEvents.Controllers.Presenter;
using OrusEvents.Core.Interfaces.Repositories;
using OrusEvents.Core.Interfaces.UseCases;
using OrusEvents.Core.UseCases;
using OrusEvents.Infrastructure;

namespace OrusEvents
{
    public class Startup
    {
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EventsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "event-app/dist";
            });

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Info
            //    {
            //        Title = "Events",
            //        Version = "v1",
            //        Description = "Api de Backend do Projeto de Eventos",
            //        Contact = contact
            //    });
            //});

            //Injecao de Dependencia dos servicos

            services.AddTransient<IEventsRepository, EventsRepository>();

            services.AddSingleton<RegisterUserInEventPresenter>();
            services.AddTransient<IRegisterUserInEventUseCase, RegisterUserInEventUseCase>();

            services.AddSingleton<RegisterConfirmationPresenter>();
            services.AddTransient<IRegisterConfirmationInEventUseCase, RegisterConfirmationInEventUseCase>();

            services.AddSingleton<GetRegisterInfoPresenter>();
            services.AddTransient<IGetRegisterInfoUseCase, GetRegisterInfoUseCase>();

            services.AddSingleton<LoginPresenter>();
            services.AddTransient<ILoginUseCase, LoginUseCase>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "event-app";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
