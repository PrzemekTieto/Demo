using System;
using System.Drawing;
using System.Drawing.Imaging;
using Contract.Models;
using ImageAcquisitionModule.Contract;
using Emgu.CV;

namespace ImageAcquisitionModule
{
    public class CameraCapture : IImageAcquisition
    {
        private readonly VideoCapture _capture;

        public CameraCapture(VideoCapture capture)
        {
            _capture = capture;
        }

        public AcquiredImage AcquireImage(ImageRequest imageRequest)
        {
            var acquiredImage = new AcquiredImage
            {
                ImageType = ImageFormat.Jpeg.ToString(),
                ImageName = Guid.NewGuid().ToString(),
                Image = CaptureImage(imageRequest),
                ImageDate = DateTime.Today,
                ImageQuality = imageRequest.ImageQuality
            };

            return acquiredImage;
        }

        private Image CaptureImage(ImageRequest imageRequest)
        {
            _capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameWidth, imageRequest.FrameWidth);
            _capture.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight, imageRequest.FrameHeight);

            Image image = _capture.QueryFrame().Bitmap; //take a picture

            return image;
        }
    }
}