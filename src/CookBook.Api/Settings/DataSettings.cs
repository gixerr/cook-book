using CookBook.Api.Settings.Interfaces;

namespace CookBook.Api.Settings
{
    public class DataSettings : IDataSettings
    {
        public bool Initialize { get; set; }
        public string ProviderType { get; set; }
    }
}
