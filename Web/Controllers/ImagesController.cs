using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Providers;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    public class ImagesController : Controller
    {
        private readonly IImageStorage _imageStorage;
        public ImagesController(IImageStorage  imageStorage)
        {
            this._imageStorage = imageStorage;
        }

        [HttpGet]
        [Route("api/images/{id:int}")]
        public async Task<HttpResponseMessage> GetImage(int id)
            => await _imageStorage.GetImageResponse(id);
    }
}