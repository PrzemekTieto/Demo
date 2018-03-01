using System;
using Contract.Models;
using ImageAcquisitionModule.Contract;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageAcquisitionModule
{
    public class ImageFromFile : IImageAcquisition
    {
        public AcquiredImage AcquireImage(ImageRequest imageRequest)
            => AcquireImageFromFile(imageRequest.ImageQuality);

        private AcquiredImage AcquireImageFromFile(long imageQuality)
        {
            var acquiredImage = new AcquiredImage
            {
                ImageType = ImageFormat.Jpeg.ToString(),
                ImageName = Guid.NewGuid().ToString(),
                Image = GetImageFromFile(),
                ImageDate = DateTime.Today,
                ImageQuality = imageQuality
            };

            return acquiredImage;
        }

        private Image GetImageFromFile()
        {
            var image = Image.FromFile(@"c:\images\1.jpg");

            return image;
        }
    }
}