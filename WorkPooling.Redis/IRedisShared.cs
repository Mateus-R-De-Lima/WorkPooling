
namespace WorkPooling.Redis
{
    public interface IRedisShared
    {
        Task<string?> GetDataAsync(string key);
        Task SaveDataAsync(string key, string value);
    }
}