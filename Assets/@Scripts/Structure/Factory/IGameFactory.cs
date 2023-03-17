using Defender.Data.Static;
using Defender.Logic;
using Defender.Service;
using UnityEngine;

namespace Defender.Factory
{
    public interface IGameFactory : IService
    {
        void CreateHud();
        void CreateSpawner(Vector2 at, string spawnerId, EnemyTypeId monsterTypeId, int waveCount, float delay);

        GameObject CreatePlayer(Vector2 initialPoint);
        GameObject CreateEnemy(EnemyTypeId typeId, Transform parent);
      
        LootPiece CreateLoot();
    }
}