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
        private const long DefaultImageQuality = 50L;
        private const int DefaultFrameWidth = 640;
        private const int DefaultFrameHeight = 480;

        public ImageResponse GetImage()
        {
            var imageRequest = new ImageRequest
            {
                ImageQuality = DefaultImageQuality,
                FrameWidth = DefaultFrameWidth,
                FrameHeight = DefaultFrameHeight
            };

            return GetImage(imageRequest);
        }

        public ImageResponse GetImage(ImageRequest imageRequest)
        {
            var imageResponse = new ImageResponse
            {
                ImageType = ImageFormat.Jpeg.ToString(),
                ImageName = Guid.NewGuid().ToString(),
                Image = CaptureImage(imageRequest),
                ImageDate = DateTime.Today,
                ImageQuality = imageRequest.ImageQuality
            };

            return imageResponse;
        }

        private string CaptureImage(ImageRequest imageRequest)
        {
            VideoCapture capture = new VideoCapture(); //create a camera capture

            capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameWidth, imageRequest.FrameWidth);
            capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight, imageRequest.FrameHeight);

            Bitmap image = capture.QueryFrame().Bitmap; //take a picture

            var imageString = ImageToBase64EncodeString(image, imageRequest.ImageQuality);

            return imageString;
        }

        private string ImageToBase64EncodeString(Image image, long imageQuality)

        {
            MemoryStream ms = new MemoryStream();

            var jpgEncoder = GetEncoder(ImageFormat.Jpeg);
            var myEncoder = Encoder.Quality;
            var myEncoderParameter = new EncoderParameter(myEncoder, imageQuality);
            var myEncoderParameters = new EncoderParameters(1);
            myEncoderParameters.Param[0] = myEncoderParameter;

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