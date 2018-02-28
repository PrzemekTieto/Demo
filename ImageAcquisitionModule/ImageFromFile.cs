using System;
using System.IO;
using System.Net.Mime;
using Contract.Models;
using ImageAcquisitionModule.Contract;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageAcquisitionModule
{
    public class ImageFromFile : IImageAcquisition
    {
        public ImageResponse GetImage()
        {
            var imageResponse = new ImageResponse
            {
                ImageType = ImageFormat.Jpeg.ToString(),
                ImageName = Guid.NewGuid().ToString(),
                Image = GetImageFromFile(),
                ImageDate = DateTime.Today,
                ImageQuality = -1
            };

            return imageResponse;
        }

        public ImageResponse GetImage(ImageRequest imageRequest)
            => GetImage();

        private string GetImageFromFile()
        {
            var image = Image.FromFile(@"c:\images\1.jpg");

            var imageString = ImageToBase64EncodeString(image);

            return imageString;
        }

        private string ImageToBase64EncodeString(Image image)

        {
            MemoryStream ms = new MemoryStream();

            image.Save(ms, image.RawFormat);

            byte[] array = ms.ToArray();

            return Convert.ToBase64String(array);

        }
    }
}