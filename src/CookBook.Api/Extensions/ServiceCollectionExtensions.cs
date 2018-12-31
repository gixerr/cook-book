using CookBook.Api.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace CookBook.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddFrameworkServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                    .AddJsonOptions(x => { x.SerializerSettings.Formatting = Formatting.Indented; });
            services.AddDbContext<CookBookDbContext>(options
                => options.UseSqlServer(configuration.GetConnectionString("Default")));
        }
    }
}
