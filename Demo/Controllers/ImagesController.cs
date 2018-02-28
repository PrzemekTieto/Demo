using System.Net;
using System.Web.Http;
using Contract.Models;
using Services.Contract;

namespace Demo.Controllers
{
    public class ImagesController : ApiController
    {
        private readonly IImageService _imageService;

        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        public ImageResponse GetImage()
        {
            var imageResponse = _imageService.GetImage();

            return imageResponse;
        }

        [HttpPost]
        public ImageResponse GetImage([FromBody] ImageRequest imageRequest)
        {
            if (!ModelState.IsValid || imageRequest == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var imageResponse = _imageService.GetImage(imageRequest);

            return imageResponse;
        }
    }
}
