using Defender.Data;
using Defender.Data.Static;

namespace Defender.Service
{
    public interface IStaticDataService : IService
    {
        MonsterStaticData ForMonster(EnemyTypeId type);
        LevelStaticData ForLevel(string sceneKey);
        WindowConfigData ForWindow(WindowId windowId);

        void LoadMonsters();
    }
}