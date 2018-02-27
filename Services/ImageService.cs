using Contract.Models;
using ImageAcquisitionModule.Contract;
using Services.Contract;

namespace Services
{
    public class ImageService : IImageService
    {
        private readonly IImageAcquisition _imageAcquisition;

        public ImageService(IImageAcquisition imageAcquisition)
        {
            _imageAcquisition = imageAcquisition;
        }
        public ImageResponse GetImage()
        {
            var imageResponse = _imageAcquisition.GetImage();

            return imageResponse;
        }
    }
}