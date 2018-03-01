using Contract.Models;
using ImageAcquisitionModule.Contract;
using Services.Contract;

namespace Services
{
    public class ImageService : IImageService
    {
        private const long DefaultImageQuality = 50;
        private const int DefaultFrameWidth = 640;
        private const int DefaultFrameHeight = 480;

        private readonly IImageAcquisition _imageAcquisition;
        private readonly IEncoder _encoder;

        public ImageService(IImageAcquisition imageAcquisition, IEncoder encoder)
        {
            _imageAcquisition = imageAcquisition;
            _encoder = encoder;
        }

        public ImageResponse GetImage()
        {
            var defaultImageRequest = new ImageRequest
            {
                ImageQuality = DefaultImageQuality,
                FrameWidth = DefaultFrameWidth,
                FrameHeight = DefaultFrameHeight
            };

            var imageResponse = GetImage(defaultImageRequest);

            return imageResponse;
        }

        public ImageResponse GetImage(ImageRequest imageRequest)
        {
            var acquiredImage = _imageAcquisition.AcquireImage(imageRequest);

            var imageResponse = new ImageResponse
            {
                Image = _encoder.Encode(acquiredImage),
                ImageDate = acquiredImage.ImageDate,
                ImageName = acquiredImage.ImageName,
                ImageQuality = acquiredImage.ImageQuality,
                ImageType = acquiredImage.ImageType
            };

            return imageResponse;
        }
    }
}