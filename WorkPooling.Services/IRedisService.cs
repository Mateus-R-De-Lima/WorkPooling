using StackExchange.Redis;

namespace WorkPooling.Services
{
    public interface IRedisService
    {
        IDatabase Db { get; }
    }
}