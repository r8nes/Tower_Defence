using Defender.Service;

namespace Defender.Data.Static
{
    public interface IStaticDataService : IService
    {
        MonsterStaticData ForMonster(EnemyTypeId type);

        void LoadMonsters();
    }
}