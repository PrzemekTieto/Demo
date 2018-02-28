using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Contract.Models;
using ImageAcquisitionModule.Contract;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;

namespace ImageAcquisitionModule
{
    public class CameraCapture : IImageAcquisition
    {
        public ImageResponse GetImage()
        {
            var imageResponse = new ImageResponse
            {
                ImageType = ImageFormat.Jpeg.ToString(),
                ImageName = Guid.NewGuid().ToString(),
                Image = CaptureImage(),
                ImageDate = DateTime.Today,
                ImageDescription = "Very pretty image"
            };

            return imageResponse;
        }

        private string CaptureImage()
        {
            VideoCapture capture = new VideoCapture(); //create a camera capture

            Bitmap image = capture.QueryFrame().Bitmap; //take a picture

            var imageString = ImageToBase64EncodeString(image);

            return imageString;
        }

        private string ImageToBase64EncodeString(Image image)

        {
            MemoryStream ms = new MemoryStream();

            var jpgEncoder = GetEncoder(ImageFormat.Jpeg);
            var myEncoder = Encoder.Quality;
            var myEncoderParameter = new EncoderParameter(myEncoder, 50L);
            var myEncoderParameters = new EncoderParameters(1);
            myEncoderParameters.Param[0] = myEncoderParameter;

            var format = image.RawFormat;

            image.Save(ms, jpgEncoder, myEncoderParameters);

            byte[] array = ms.ToArray();

            return Convert.ToBase64String(array);

        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }
}