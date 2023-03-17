using Defender.Data.Static;

namespace Defender.Service
{
    public interface IStaticDataService : IService
    {
        MonsterStaticData ForMonster(EnemyTypeId type);
        LevelStaticData ForLevel(string sceneKey);

        void LoadMonsters();
    }
}