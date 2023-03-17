using Defender.Service;

namespace Defender.Factory
{
    public interface IRandomService : IService
    {
        int Next(int minValue, int maxValue);
    }
}