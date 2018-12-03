using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace CookBook.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddFrameworkServices(this IServiceCollection services)
        {
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                    .AddJsonOptions(x => { x.SerializerSettings.Formatting = Formatting.Indented; });
        }
    }
}
