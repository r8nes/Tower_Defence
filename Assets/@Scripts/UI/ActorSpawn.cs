using Defender.Logic;
using UnityEngine;

namespace Defender.UI
{
    public class ActorSpawn : MonoBehaviour
    {
        public SpawnBar SpawnBar;
        private SpawnPoint _spawnPoint;

        private void Start()
        {
            UpdateSpawnBar(0);
            UpdateWaveText(0);
        }
        private void OnDisable()
        {
            _spawnPoint.OnSpawnEnemiesAppeared -= UpdateSpawnBar;
            _spawnPoint.OnWaveChanged -= UpdateWaveText;
        }

        public void Construct(SpawnPoint spawnPoint)
        {
            _spawnPoint = spawnPoint;

            _spawnPoint.OnSpawnEnemiesAppeared += UpdateSpawnBar;
            _spawnPoint.OnWaveChanged += UpdateWaveText;
        }

        private void UpdateSpawnBar(int count)
        {
            SpawnBar.SetBarValue(count, _spawnPoint.EnemiesPerWave);
            SpawnBar.SetEnemiesTextValue(count, _spawnPoint.EnemiesPerWave);
        }

        private void UpdateWaveText(int count) => SpawnBar.SetWaveTextValue(count);
    }
}
