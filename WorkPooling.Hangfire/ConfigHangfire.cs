using Hangfire;
using Hangfire.Redis.StackExchange;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkPooling.Redis;
using WorkPooling.Services;

namespace WorkPooling.Hangfire
{
    public static class ConfigHangfire
    {
        public static void AddConfigHangfire(this IServiceCollection services, IConfiguration configuration)
        {
            // Pega a connection string do Redis
            var redisConn = configuration.GetConnectionString("Redis");

            // Configura Hangfire para usar Redis
            services.AddHangfire(config =>
            {
                config.UseRedisStorage(redisConn, new RedisStorageOptions
                {
                    Prefix = "hangfire:myapp:" // prefixo para separar chaves no Redis
                });
            });

            // Registrar o servidor Hangfire (background service)
            services.AddHangfireServer();


        }

        /// <summary>
        /// Método para agendar jobs recorrentes usando IRecurringJobManager via DI
        /// Deve ser chamado após Build() do WebApplication
        /// </summary>
        public static void ConfigureJobs(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var recurringJobManager = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();
            var job = scope.ServiceProvider.GetRequiredService<IConsumeThirdPartyApiJob>();

            // Agendamento a cada 30 segundos
            recurringJobManager.AddOrUpdate(
                "ConsumeThirdPartyApiJob",
                () => job.Execute(),
                "*/30 * * * * *"
            );
        }




    }
}
