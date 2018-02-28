using Contract.Models;

namespace Contract
{
    public interface IImage
    {
        ImageResponse GetImage(ImageRequest imageRequest);

        ImageResponse GetImage();

    }
}