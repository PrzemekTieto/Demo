using System;

namespace Contract.Models
{
    public class ImageResponse
    {
        public string ImageName { get; set; }
        public string ImageType { get; set; }
        public string ImageDescription { get; set; }
        public DateTime ImageDate { get; set; }
        public string Image { get; set; }
    }
}