using System;
using System.Net.Http;

namespace Data.ImageProviders {
    public class ImageProvider {
        public readonly HttpClient _httpClient;

        public ImageProvider()
        {
            _httpClient = new HttpClient();
            
        }

        public string GetImage (string id)
        {
            throw new NotImplementedException();
        }
    }
}