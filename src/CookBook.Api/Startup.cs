using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CookBook.Api.Extensions;
using CookBook.Api.Middleware;
using CookBook.Infrastructure.DataInitializers;
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
        }

        public IConfiguration Configuration { get; }
        public IContainer Container { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddFrameworkServices(Configuration);
            var builder = new ContainerBuilder();
            builder.RegisterRepositoryModule(Configuration)
                   .RegisterServicesModule()
                   .RegisterDataInitializers()
                   .RegisterCommandModule()
                   .RegisterAutoMapper()
                   .Populate(services);
            Container = builder.Build();

            return new AutofacServiceProvider(Container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
            var dataInitializer = app.ApplicationServices.GetService<IDataInitializer>();
            dataInitializer.Initialize();
            applicationLifetime.ApplicationStopped.Register(() => Container.Dispose());
        }
    }
}
