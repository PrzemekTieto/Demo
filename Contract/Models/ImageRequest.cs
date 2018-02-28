using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Models
{
    public class ImageRequest
    {
        public long ImageQuality { get; set; }
        public int FrameWidth { get; set; }
        public int FrameHeight { get; set; }
    }
}
