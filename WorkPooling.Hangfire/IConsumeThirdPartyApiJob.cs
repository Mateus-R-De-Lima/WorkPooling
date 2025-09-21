
namespace WorkPooling.Hangfire
{
    public interface IConsumeThirdPartyApiJob
    {
        Task Execute();
    }
}