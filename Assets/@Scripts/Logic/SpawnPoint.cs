using System;
using System.Collections;
using System.Collections.Generic;
using Defender.Data;
using Defender.Factory;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Defender.Logic
{
    public class SpawnPoint : MonoBehaviour
    {
        public string Id { get; set; }

        public EnemyTypeId MonsterTypeId;

        public int WaveCount = 2;
        public int EnemiesPerWave = 10;
        public float SpawnInterval = 1.5f;

        private float _nextSpawnTime;

        private IGameFactory _factory;
        private List<SpawnerTransform> _points = new List<SpawnerTransform>();

        public event Action<int> OnSpawnEnemiesAppeared;
        public event Action<int> OnWaveChanged;

        public int CurrentWave { get; private set; }
        private Coroutine spawnCoroutine;

        private void Start()
        {
            spawnCoroutine = StartCoroutine(SpawnWave(CurrentWave));
        }

        public void Construct(IGameFactory factory)
        {
            _factory = factory;
        }

        public void AddSpawnMarker(SpawnerTransform marker) => _points.Add(marker);

        private void Spawn(Vector2 at) => _factory.CreateEnemy(MonsterTypeId, at);

        // совсем плохая и джуновская конструкция, но в рамках прототипа, пока сойдёт
        private IEnumerator SpawnWave(int waveIndex)
        {
            if (waveIndex >= WaveCount) yield break;
            
            for (int i = 1; i <= EnemiesPerWave; i++)
            {
                int spawnIndex = Random.Range(0, _points.Count);
                Vector2 spawnPosition = _points[spawnIndex].Transform;

                Spawn(spawnPosition);     
                OnSpawnEnemiesAppeared?.Invoke(i);

                yield return new WaitForSeconds(0.5f); 
            }

            yield return new WaitForSeconds(SpawnInterval);

            CurrentWave++;
            OnWaveChanged?.Invoke(CurrentWave);

            if (CurrentWave < WaveCount)
        {
                spawnCoroutine = StartCoroutine(SpawnWave(CurrentWave));
            }
        }
    }
}