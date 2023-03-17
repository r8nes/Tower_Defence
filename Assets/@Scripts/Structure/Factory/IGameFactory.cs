using System.Collections.Generic;
using Defender.Data.Static;
using Defender.Logic;
using Defender.Service;
using UnityEngine;

namespace Defender.Factory
{
    public interface IGameFactory : IService
    {
        List<ISavedProgressReader> ProgressReader { get; }
        List<ISavedProgress> ProgressWriters { get; }

        void CreateHud();
        void CreateSpawner(Vector2 at, string spawnerId, EnemyTypeId monsterTypeId, int waveCount, float delay);

        GameObject CreatePlayer(Vector2 initialPoint);
        GameObject CreateEnemy(EnemyTypeId typeId, Transform parent);
      
        LootPiece CreateLoot();
    }
}