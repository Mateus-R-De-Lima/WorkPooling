namespace WorkPooling.Services
{
    public class AdviceSlipServices(
        IHttpClientFactory client) : IAdviceSlipServices
    {

        public  async Task<string> Get()
        {
            var http = client.CreateClient();

            var response = http.GetAsync("https://api.adviceslip.com/advice");


            return await response.Result.Content.ReadAsStringAsync();
        }
    }
}
