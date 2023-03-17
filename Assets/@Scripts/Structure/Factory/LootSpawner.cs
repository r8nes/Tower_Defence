using Defender.Entity;
using Defender.Logic;
using UnityEngine;

namespace Defender.Factory
{
    public class LootSpawner : MonoBehaviour
    {
        public EnemyDeath EnemyDeath;

        private int _lootMin;
        private int _lootMax;

        private IGameFactory _factory;
        private IRandomService _random;

        public void Construct(IGameFactory factory, IRandomService random)
        {
            _factory = factory;
            _random = random;
        }

        private void Start()
        {
            EnemyDeath.DeathHappend += SpawnLoot;
        }

        private void SpawnLoot()
        {
            EnemyDeath.DeathHappend -= SpawnLoot;

            LootPiece loot = _factory.CreateLoot();
            loot.transform.position = transform.position;

            Loot lootItem = GenerateLoot();
            loot.Initialize(lootItem);
        }

        private Loot GenerateLoot()
        {
            return new Loot
            {
                Value = _random.Next(_lootMin, _lootMax)
            };
        }

        public void SetLoot(int min, int max)
        {
            _lootMin = min;
            _lootMax = max;
        }
    }
}