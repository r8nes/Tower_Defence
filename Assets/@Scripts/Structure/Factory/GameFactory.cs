using System.Collections.Generic;
using Defender.Assets;
using Defender.Data.Static;
using Defender.Entity;
using Defender.Logic;
using Defender.Service;
using UnityEngine;

namespace Defender.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IRandomService _random;
        private readonly IAssetsProvider _assets;
        private readonly IStaticDataService _staticData;
        private readonly IProgressService _progressService;

        private GameObject PlayerGameObject { get; set; }

        public List<ISavedProgressReader> ProgressReader => new List<ISavedProgressReader>();

        public List<ISavedProgress> ProgressWriters => new List<ISavedProgress>();

        public GameFactory(IAssetsProvider assets, IStaticDataService staticData, IRandomService random, IProgressService progressService)
        {
            _assets = assets;
            _staticData = staticData;
            _random = random;
            _progressService = progressService;
        }

        public void CreateHud() => _assets.Instantiate(AssetsPath.GLOBAL_HUD_PATH);

        public GameObject CreatePlayer(Vector2 initialPoint) => PlayerGameObject =
            _assets.Instantiate(AssetsPath.PLAYER_PATH, point: initialPoint);

        public GameObject CreateEnemy(EnemyTypeId typeId, Transform parent)
        {
            MonsterStaticData monsterData = _staticData.ForMonster(typeId);
            GameObject monster = Object.Instantiate(monsterData.Prefab, parent.position, Quaternion.identity, parent);

            var health = monster.GetComponent<IHealth>();

            health.Current = monsterData.Hp;
            health.Max = monsterData.Hp;

            monster.GetComponent<EnemyMovement>().Construct(PlayerGameObject.transform, monsterData.Speed);

            var lootSpawner = monster.GetComponentInChildren<LootSpawner>();

            lootSpawner.SetLoot(monsterData.MinLoot, monsterData.MaxLoot);
            lootSpawner.Construct(this, _random);

            return monster;
        }

        public void CreateSpawner(Vector2 at, string spawnerId, EnemyTypeId monsterTypeId, int waveCount, float delay)
        {
            SpawnPoint spawner = _assets.Instantiate(AssetsPath.SPAWNER_PATH, at)
                .GetComponent<SpawnPoint>();

            spawner.Construct(this);
            spawner.Id = spawnerId;
            spawner.MonsterTypeId = monsterTypeId;

            spawner.StartSpawn();
        }

        public LootPiece CreateLoot()
        {
            LootPiece loot = _assets.Instantiate(AssetsPath.LOOT_PATH)
                .GetComponent<LootPiece>();

            loot.Construct(_progressService.Progress.WorldData);

            return loot;
        }
    }
}