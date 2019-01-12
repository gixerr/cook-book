using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CookBook.Api.Extensions;
using CookBook.Api.Middleware;
using CookBook.Api.Settings.Interfaces;
using CookBook.Infrastructure.DataInitializers.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CookBook.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            DataSettings = configuration.GetDataSettings();
        }

        public IConfiguration Configuration { get; }
        public IContainer Container { get; private set; }
        public IDataSettings DataSettings { get;}

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddFrameworkServices(Configuration);
            var builder = new ContainerBuilder();
            builder.RegisterRepositoryModule(DataSettings.ProviderType)
                   .RegisterServicesModule()
                   .RegisterDataInitializers()
                   .RegisterCommandModule()
                   .RegisterAutoMapper()
                   .Populate(services);
            Container = builder.Build();

            return new AutofacServiceProvider(Container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHttpsRedirection();
                app.UseHsts();
            }

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseStaticFiles();
            app.UseMvc();
            if (DataSettings.Initialize)
            {
                var dataInitializer = app.ApplicationServices.GetService<IDataInitializer>();
                dataInitializer.Initialize();
            }
            applicationLifetime.ApplicationStopped.Register(() => Container.Dispose());
        }
    }
}
