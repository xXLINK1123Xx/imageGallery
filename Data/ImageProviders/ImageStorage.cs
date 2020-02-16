using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Infrastructure.Models;
using Infrastructure.Providers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Data.ImageProviders {
    public class ImageStorage : IImageStorage
    {
        private readonly HttpClient _httpClient;
        private readonly IDataProvider<Post> _postProvider;
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _config;

        public ImageStorage(IDataProvider<Post> postProvider, IConfiguration config, IWebHostEnvironment env)
        {
            _httpClient = new HttpClient();
            _postProvider = postProvider;
            _env = env;
            _config = config;
        }

        public async Task<string> GetImage(Post post)
        {
            var webRoot = _env.WebRootPath;
            var dir = Path.Combine(webRoot, 
                "images");

            var fileList = Directory.GetFiles(dir, $"{post.Id}.{post.FileExt}");

            if (fileList.Length > 0)
            {
                return $"{_config["hostname"]}/images/{post.Id}.{post.FileExt}";
            }

            return await SaveImage(post);
        }
        
        public async Task<string> SaveImage(Post post)
        {
            
            var webRoot = _env.WebRootPath;
            var dir = Path.Combine(webRoot, "images", $"{post.Id}.{post.FileExt}");

            var resp = await _httpClient.GetAsync(post.FileUrl);
            var bytes = await resp.Content.ReadAsByteArrayAsync();
            var memory = new MemoryStream(bytes);
            await using (var stream = new FileStream(dir, FileMode.Create))
            {
                await memory.CopyToAsync(stream);
            }
            memory.Position = 0;

            return $"{_config["hostname"]}/images/{post.Id}.{post.FileExt}";
        }
    }
}