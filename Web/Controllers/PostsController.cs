using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Data.Danbooru;
using Data.ImageProviders;
using Data.Services;
using Infrastructure.Models;
using Infrastructure.Providers;
using Microsoft.AspNetCore.Mvc;
using VkNet;

namespace Web.Controllers
{
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly DanbooruApiWrapper _danbooruApiWrapper;
        private readonly IDataProvider<Post> _dataProvider;
        private readonly IImageStorage _imageProvider;
        private readonly VkService _vkService;

        public PostsController(DanbooruApiWrapper danbooruApiWrapper, IDataProvider<Post> dataProvider, IImageStorage imageStorage, VkService vkService)
        {
            this._danbooruApiWrapper = danbooruApiWrapper;
            this._dataProvider = dataProvider;
            this._imageProvider = imageStorage;
            _vkService = vkService;
        }

        [HttpGet]
        [Route("api/posts")]
        public async Task<List<Post>> GetImages(int page = 1, string tags = null)
        {
            var imgs =  await _danbooruApiWrapper.GetPosts(page,
                tags?.Split('+').Select(t => new Tag {Name = t, Type = Tag.TagType.Standard}).ToArray());
            
            _dataProvider.SaveMany(imgs);
            
            return imgs;
        }

        [HttpGet]
        [Route("api/posts/{id:int}")]
        public async Task<Post> GetImage(int id)
        {
            var post = _dataProvider.Get(id);
            post.FileUrl = await _imageProvider.GetImage(post);
            return post;
        }

        [HttpPost]
        [Route("api/posts/repost")]
        public async Task<HttpResponseMessage> Repost(RepostInfo info)
        {
            await _vkService.RepostPost(info);
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
    }
}