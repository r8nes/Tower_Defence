using System.Collections;
using Defender.Data.Static;
using Defender.Entity;
using Defender.Factory;
using UnityEngine;

namespace Defender.Logic
{
    public class SpawnPoint : MonoBehaviour 
    { 
        public string Id { get; set; }

        public EnemyTypeId MonsterTypeId;

        private float _spawnStep = 2f;

        private IGameFactory _factory;

        public void Construct(IGameFactory factory)
        {
            _factory = factory;
        }

        private void Spawn()
        {
            _factory.CreateEnemy(MonsterTypeId, transform);
        }

        public void StartSpawn() 
        {
            StartCoroutine(StartWave());
        }

        private IEnumerator StartWave() 
        {
            yield return new WaitForSeconds(_spawnStep);
            Spawn();
        }
    }
}