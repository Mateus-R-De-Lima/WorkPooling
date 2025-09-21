using Quartz;
using WorkPooling.Services;

namespace WorkPooling.Quartz
{
    public class ConsumeThirdPartyApiJob(
       IAdviceSlipServices services) : IJob
    {


        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"[{DateTime.Now}] Executando Job...");

            var response = services.Get();

        }
    }
}
