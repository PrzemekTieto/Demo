using System;
using System.Drawing;

namespace ImageAcquisitionModule.Contract
{
    public class AcquiredImage
    {
        public string ImageName { get; set; }
        public string ImageType { get; set; }
        public long ImageQuality { get; set; }
        public DateTime ImageDate { get; set; }
        public Image Image { get; set; }
    }
}
