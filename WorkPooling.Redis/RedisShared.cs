using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPooling.Services;

namespace WorkPooling.Redis
{
    public class RedisShared(IRedisService redis) : IRedisShared
    {

        public async Task SaveDataAsync(string key, string value)
        {
            await redis.Db.StringSetAsync(key, value);
        }

        public async Task<string?> GetDataAsync(string key)
        {
            return await redis.Db.StringGetAsync(key);
        }
    }
}
