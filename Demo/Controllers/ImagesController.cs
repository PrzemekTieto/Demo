using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    }
}
