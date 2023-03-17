using Defender.Data;

namespace Defender.Service
{
    public interface ISaveLoadService : IService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();

        void PrintPlayerPrefs();
    }
}