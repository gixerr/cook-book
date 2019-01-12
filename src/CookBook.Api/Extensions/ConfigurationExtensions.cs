using CookBook.Api.Settings;
using CookBook.Api.Settings.Interfaces;
using Microsoft.Extensions.Configuration;

namespace CookBook.Api.Extensions
{
    public static class ConfigurationExtensions
    {
        public static IDataSettings GetDataSettings(this IConfiguration configuration)
        {
            var dataSettings = new DataSettings();
            configuration.GetSection("dataSettings").Bind(dataSettings);

            return dataSettings;
        }
    }
}
