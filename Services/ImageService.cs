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

        public ImageResponse GetImage(ImageRequest imageRequest)
        {
            var imageResponse = _imageAcquisition.GetImage(imageRequest);

            return imageResponse;
        }
    }
}