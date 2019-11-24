using System.Net.Http;

namespace Data.Danbooru
{
    public class DanbooruApiWrapper
    {
        private readonly HttpClient httpClient;

        public DanbooruApiWrapper()
        {
            httpClient = new HttpClient();
        }
    }
}