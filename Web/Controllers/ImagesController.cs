using System.Net.Http;
using System.Threading.Tasks;
using Data.ImageProviders;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    public class ImagesController : Controller
    {
        private readonly ImageStorage _imageStorage;
        public ImagesController(ImageStorage imageStorage)
        {
            this._imageStorage = imageStorage;
        }

        [HttpGet]
        [Route("api/images/{id:int}")]
        public async Task<HttpResponseMessage> GetImage(int id)
            => await _imageStorage.GetImageResponse(id);
    }
}