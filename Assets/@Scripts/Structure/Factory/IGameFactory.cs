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
        SpawnPoint CreateSpawner();

        GameObject CreateHud();
        LootPiece CreateLoot();
        GameObject CreatePlayer(Vector2 initialPoint);
        GameObject CreateEnemy(EnemyTypeId typeId, Vector2 parent);
    }
}