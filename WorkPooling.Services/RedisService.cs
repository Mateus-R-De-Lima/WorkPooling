using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPooling.Services
{
    public class RedisService : IRedisService
    {
        private readonly ConnectionMultiplexer _redis;
        public IDatabase Db => _redis.GetDatabase();

        public RedisService(IConfiguration configuration)
        {
            // Pega a connection string do Redis
            var redisConn = configuration.GetConnectionString("Redis") ;

            _redis = ConnectionMultiplexer.Connect(redisConn);
        }
    }
}
