using ImageAcquisitionModule.Contract;
using Services.Contract;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Services
{
    public class Base64Encoder : IEncoder
    {
        public string Encode(AcquiredImage image)
        {
            var encodedImage = ImageToBase64EncodeString(image.Image, image.ImageQuality);

            return encodedImage;
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
