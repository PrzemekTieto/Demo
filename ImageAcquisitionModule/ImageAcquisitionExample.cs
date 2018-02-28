using Contract.Models;
using ImageAcquisitionModule.Contract;

namespace ImageAcquisitionModule
{
    public class ImageAcquisitionExample : IImageAcquisition
    {
        public ImageResponse GetImage()
        {
            throw new System.NotImplementedException();
        }

        public ImageResponse GetImage(ImageRequest imageRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}