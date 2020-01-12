using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Models;
using Infrastructure.Providers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Data.Danbooru
{
    public class DanbooruApiWrapper: IApiProvider
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _apiLogin;

        public DanbooruApiWrapper(IConfiguration config, IDataProvider<Post> dataProvider)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(config["danbooruHost"]);
            _apiKey = config["api_key"];
            _apiLogin = config["username"];
        }

        public async Task<List<Post>> GetPosts(int page = 1, Tag[] tags = null)
        {
            var query = new StringBuilder("/posts.json?");
            
            query.Append($"{_apiLogin}={_apiKey}");
            query.Append($"&page={page}");
            if (tags != null)
            {
                query.Append("&tags=");
                query.AppendJoin("+", tags.AsEnumerable());
            }


            var response = await _httpClient.GetAsync(query.ToString());
            if (response.IsSuccessStatusCode)
            {
                var imagesJson = JArray.Parse(await response.Content.ReadAsStringAsync());
                var images = imagesJson.Where(IsAllowedImageType).Select(ParseJson);

                return images.ToList();
            }

            throw new Exception("bad request");
        }

        public async Task<List<Tag>> GetTags()
        {
            throw new NotImplementedException();
        }

        private Post ParseJson(JToken json)
        {
            var id = json["id"].Value<int>();
            //var fileUrl = json["file_url"].Value<string>();
            var image = new Post
            {
                Id = json["id"].Value<int>(),
                FileUrl = json.SelectToken("large_file_url")?.Value<string>(),
                PreviewFileUrl = json.SelectToken("preview_file_url")?.Value<string>(),
                FileExt = json.SelectToken("file_ext")?.Value<string>(),
                Artist = json.SelectToken("tag_string_artist")?.Value<string>(),
                Tags = json.SelectToken("tag_string_general")?.Value<string>()
                    .Split(" ")
                    .Select(tag => 
                        new Tag
                        {
                            Name = tag, 
                            Type = Tag.TagType.Standard
                        }).ToArray(),
                Characters = new[] {json.SelectToken("tag_string_character")?.Value<string>()}
            };
            
            return image;
        }

        private bool IsAllowedImageType(JToken json)
        {
            var tags = json["tag_string_meta"].Value<string>().Split(" ");
            
            return !tags.Contains("animated");
        }
    }
}