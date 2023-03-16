using Defender.Assets;
using Defender.Data.Static;
using Defender.Entity;
using UnityEngine;

namespace Defender.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IRandomService _random;
        private readonly IAssetsProvider _assets;
        private readonly IStaticDataService _staticData;

        private GameObject PlayerGameObject { get; set; }

        public GameFactory(IAssetsProvider assets, IStaticDataService staticData, IRandomService random)
        {
            _assets = assets;
            _staticData = staticData;
            _random = random;
        }

        public void CreateHud() => _assets.Instantiate(AssetsPath.GLOBAL_HUD_PATH);

        public GameObject CreatePlayer(GameObject initialPoint) => PlayerGameObject =
            _assets.Instantiate(AssetsPath.PLAYER_PATH, point: initialPoint.transform.position);

        public GameObject CreateMonster(EnemyTypeId typeId, Transform parent)
        {
            MonsterStaticData monsterData = _staticData.ForMonster(typeId);
            GameObject monster = Object.Instantiate(monsterData.Prefab, parent.position, Quaternion.identity, parent);

            var health = monster.GetComponent<IHealth>();

            health.Current = monsterData.Hp;
            health.Max = monsterData.Hp;

            monster.GetComponent<EnemyMovement>().Construct(PlayerGameObject.transform);

            //var lootSpawner = monster.GetComponentInChildren<LootSpawner>();

            //lootSpawner.SetLoot(monsterData.MinLoot, monsterData.MaxLoot);
            //lootSpawner.Construct(this, _random);

            if (monster.TryGetComponent(out EnemyMovement movement))
                movement.Construct(PlayerGameObject.transform);

            return monster;
        }
    }
}