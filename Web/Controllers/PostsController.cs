using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Danbooru;
using Infrastructure.Models;
using Infrastructure.Providers;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly DanbooruApiWrapper _danbooruApiWrapper;
        private readonly IDataProvider<Post> _dataProvider;

        public PostsController(DanbooruApiWrapper danbooruApiWrapper, IDataProvider<Post> dataProvider)
        {
            this._danbooruApiWrapper = danbooruApiWrapper;
            this._dataProvider = dataProvider;
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
            post.FileUrl = await _danbooruApiWrapper.GetImage(post);
            return post;
        }
    }
}