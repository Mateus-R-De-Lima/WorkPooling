using WorkPooling.Redis;
using WorkPooling.Services;

namespace WorkPooling.Hangfire
{
    public class ConsumeThirdPartyApiJob(
       IAdviceSlipServices services, IRedisShared redisShared) : IConsumeThirdPartyApiJob
    {


        public async Task Execute()
        {
            Console.WriteLine($"[{DateTime.Now}] Executando Job...");

            // Recupera dados anteriores do Redis
            var cachedData = await redisShared.GetDataAsync("AdviceSlip");
            if (!string.IsNullOrEmpty(cachedData))
            {
                Console.WriteLine($"Dado no Redis: {cachedData}");
            }

            // Chamada à API
            var response = await services.Get();

            Console.WriteLine($"Resposta da API: {response}");

            // Salva no Redis
            await redisShared.SaveDataAsync("AdviceSlip", response);

        }
    }
}
