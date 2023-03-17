using Defender.Data;

namespace Defender.Service
{
    public interface IProgressService : IService
    {
        PlayerProgress Progress { get; set; }
    }
}
