using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Danbooru;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("images")]
    public class ImagesController : ControllerBase
    {
        private readonly DanbooruApiWrapper dataProvider;

        public ImagesController(DanbooruApiWrapper dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        [HttpGet]
        [Route("")]
        public async Task<List<Image>> GetImages(int page = 1, string tags = null)
        {
            var imgs =  await dataProvider.GetImages(page,
                tags?.Split('+').Select(t => new Tag {Name = t, Type = Tag.TagType.Standard}).ToArray());

            return imgs;
        }
    }
}