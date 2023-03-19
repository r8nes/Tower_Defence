using System.Collections;
using System.Collections.Generic;
using Defender.Data;
using Defender.Factory;
using UnityEngine;

namespace Defender.Logic
{
    public class SpawnPoint : MonoBehaviour
    {
        public string Id { get; set; }

        public EnemyTypeId MonsterTypeId;

        public int WaveCount = 2;
        public int EnemiesPerWave = 10;
        public float SpawnInterval = 1f;

        private float _nextSpawnTime;

        private IGameFactory _factory;
        
        private List<SpawnerTransform> _points = new List<SpawnerTransform>();

        public void Construct(IGameFactory factory)
        {
            _factory = factory;
        }

        private void Update()
        {
            if (Time.time >= _nextSpawnTime)
                StartCoroutine(SpawnWave());

            _nextSpawnTime = Time.time + SpawnInterval;
        }

        public void AddSpawnMarker(SpawnerTransform marker) => _points.Add(marker);

        private void Spawn(Vector2 at) => _factory.CreateEnemy(MonsterTypeId, at);

        IEnumerator SpawnWave()
        {
            for (int i = 0; i < EnemiesPerWave; i++)
            {
                int spawnIndex = Random.Range(0, _points.Count);
                Vector2 spawnPosition = _points[spawnIndex].Transform;

                Spawn(spawnPosition);     
                yield return new WaitForSeconds(0.5f); 
            }
            WaveCount++;
        }
    }
}