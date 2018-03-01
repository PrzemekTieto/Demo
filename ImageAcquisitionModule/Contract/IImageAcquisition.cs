using Contract;
using Contract.Models;
using System.Drawing;

namespace ImageAcquisitionModule.Contract
{
    public interface IImageAcquisition
    {
        AcquiredImage AcquireImage(ImageRequest imageRequest);
    }
}