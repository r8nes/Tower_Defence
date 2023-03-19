using System.Collections.Generic;
using Defender.Assets;
using Defender.Data;
using Defender.Data.Static;
using Defender.Entity;
using Defender.Logic;
using Defender.Service;
using Defender.UI;
using UnityEngine;

namespace Defender.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IRandomService _random;
        private readonly IAssetsProvider _assets;
        private readonly IWindowService _windowService;
        private readonly IStaticDataService _staticData;
        private readonly IProgressService _progressService;

        private GameObject PlayerGameObject { get; set; }

        public List<ISavedProgressReader> ProgressReader => new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressWriters => new List<ISavedProgress>();

        public GameFactory(IAssetsProvider assets, IStaticDataService staticData, IRandomService random, IProgressService progressService, IWindowService windowService)
        {
            _assets = assets;
            _random = random;
            _staticData = staticData;
            _windowService = windowService;
            _progressService = progressService;
        }

        public void Cleanup()
        {
            ProgressReader.Clear();
            ProgressWriters.Clear();
        }

        #region CreateMethods

        public void CreateSpawner(Vector2 at, string spawnerId, EnemyTypeId monsterTypeId, int waveCount, float delay)
        {
            SpawnPoint spawner = InstantiateRegistered(AssetsPath.SPAWNER_PATH, at)
                .GetComponent<SpawnPoint>();

            spawner.Construct(this);
            spawner.Id = spawnerId;
            spawner.MonsterTypeId = monsterTypeId;

            spawner.StartSpawn();
        }

        public GameObject CreateHud()
        {
            GameObject hud = InstantiateRegistered(AssetsPath.GLOBAL_HUD_PATH);

            hud.GetComponentInChildren<LootCounter>().Construct(_progressService.Progress.WorldData);

            foreach (ActorButton button in hud.GetComponentsInChildren<ActorButton>())
                button.Construct(_progressService.Progress);

            foreach (OpenWindowButton window in hud.GetComponentsInChildren<OpenWindowButton>())
                window.Construct(_windowService); 

            return hud;
        }

        public LootPiece CreateLoot()
        {
            LootPiece loot = InstantiateRegistered(AssetsPath.LOOT_PATH)
                .GetComponent<LootPiece>();

            loot.Construct(_progressService.Progress.WorldData);
            return loot;
        }

        public GameObject CreatePlayer(Vector2 initialPoint)
        {
            PlayerGameObject = InstantiateRegistered(AssetsPath.PLAYER_PATH, initialPoint);

            PlayerGameObject.GetComponent<PlayerAttack>().Construct(_progressService.Progress);
            PlayerGameObject.GetComponent<PlayerHealth>().Construct(_progressService.Progress, _windowService);

            PlayerGameObject.GetComponentInChildren<AggroZone>().Construct(_progressService.Progress);

            return PlayerGameObject;
        }

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

        #endregion

        /* Регистрация объектов сейчас пустует, ибо сохранять данные пока не нужно.
            Но я добавил этот сервис в прототип, если захочу с ним сделать что-то в дальнейшем */

        #region RegisterMethods

        public void Register(ISavedProgressReader reader)
        {
            if (reader is ISavedProgress writer)
                ProgressWriters.Add(writer);

            ProgressReader.Add(reader);
        }

        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (ISavedProgressReader progressReader in gameObject.GetComponents<ISavedProgressReader>())
                Register(progressReader);
        }

        private GameObject InstantiateRegistered(string prefabPath, Vector2 at)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath, at);
            RegisterProgressWatchers(gameObject);

            return gameObject;
        }

        private GameObject InstantiateRegistered(string prefabPath)
        {
            GameObject gameObject = _assets.Instantiate(path: prefabPath);
            RegisterProgressWatchers(gameObject);

            return gameObject;
        }

        #endregion
    }
}