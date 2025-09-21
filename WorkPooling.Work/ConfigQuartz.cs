using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace WorkPooling.Quartz
{
    public static class ConfigQuartz
    {

        public static void AddConfigQuartz(this IServiceCollection services)
        {

            // Quartz
            services.AddQuartz(q =>
            {
                var jobKey = new JobKey("ConsumeThirdPartyApiJob");

                q.AddJob<ConsumeThirdPartyApiJob>(opts => opts.WithIdentity(jobKey));

                q.AddTrigger(opts => opts
                    .ForJob(jobKey)
                    .WithIdentity("ConsumeThirdPartyApiJob-trigger")
                    .WithCronSchedule("0/30 * * * * ?") //a cada 30 segundos
                   //.WithSimpleSchedule(x => x.WithIntervalInSeconds(30).RepeatForever())
                );
            });

            services.AddQuartzHostedService(opt => opt.WaitForJobsToComplete = false);
        }

    }
}
