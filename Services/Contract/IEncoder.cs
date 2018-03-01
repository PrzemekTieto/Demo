using ImageAcquisitionModule.Contract;

namespace Services.Contract
{
    public interface IEncoder
    {
        string Encode(AcquiredImage image);
    }
}
