namespace CookBook.Api.Settings.Interfaces
{
    public interface IDataSettings
    {
        bool Initialize { get; }
        string ProviderType { get; }
    }
}
