using System.Collections.Generic;
using Defender.Data;
using Defender.Logic;
using Defender.Service;
using UnityEngine;

namespace Defender.Factory
{
    public interface IGameFactory : IService
    {
        List<ISavedProgress> ProgressWriters { get; }
        List<ISavedProgressReader> ProgressReader { get; }

        void Cleanup();
        void CreateHud();
        void CreateSpawner(Vector2 at, string spawnerId, EnemyTypeId monsterTypeId, int waveCount, float delay);

        LootPiece CreateLoot();
        GameObject CreatePlayer(Vector2 initialPoint);
        GameObject CreateEnemy(EnemyTypeId typeId, Transform parent);
    }
}