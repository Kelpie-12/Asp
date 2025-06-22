namespace API.Services
{
    public interface IStorageServices
    {
        string GetValue(string key);
        void SetValue(string key, string value);
    }
}
