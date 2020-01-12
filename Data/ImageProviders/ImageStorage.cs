using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Infrastructure.Models;
using Infrastructure.Providers;

namespace Data.ImageProviders {
    public class ImageStorage {
        private readonly HttpClient _httpClient;
        private readonly IDataProvider<Post> _postProvider;
        
        public ImageStorage(IDataProvider<Post> postProvider)
        {
            _httpClient = new HttpClient();
            this._postProvider = postProvider;
        }

        public async Task<string> GetImage(Post post)
        {
            var dir = Path.Combine(Directory.GetCurrentDirectory(), 
                @"App_Data\images");

            var fileList = Directory.GetFiles(dir, $"{post.Id}.{post.FileExt}");

            if (fileList.Length > 0)
            {
                return $"Data/images/{post.Id}.{post.FileExt}";
            }

            return await SaveImage(post);
        }
        
        public async Task<string> SaveImage(Post post)
        {
            var dir = Path.Combine(Directory.GetCurrentDirectory(), 
                @"App_Data\images", $"{post.Id}.{post.FileExt}");

            var resp = await _httpClient.GetAsync(post.FileUrl);
            var bytes = await resp.Content.ReadAsByteArrayAsync();
            var memory = new MemoryStream(bytes);
            await using (var stream = new FileStream(dir, FileMode.Create))
            {
                await memory.CopyToAsync(stream);
            }
            memory.Position = 0;

            return $"Data/images/{post.Id}.{post.FileExt}";
        }

        public async Task<HttpResponseMessage> GetImageResponse(int postId)
        {
            var post = _postProvider.Get(postId);
            if(post != null)
            {
                return await _httpClient.GetAsync(post.FileUrl);
            }
            
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }
    }
}