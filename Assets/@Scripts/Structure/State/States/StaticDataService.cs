using System.Collections.Generic;
using System.Linq;
using Defender.Data;
using Defender.Data.Static;
using UnityEngine;

namespace Defender.Service
{
    public class StaticDataService : IStaticDataService
    {
        private const string LEVELS_PATH = "Data/Levels";
        private const string SPAWNER_DATA = "Data/Spawner/SpawnerData";
        private const string MONSTERS_PATH = "Data/Enemies";
        private const string WINDOWS_PATH = "Data/Windows/WindowData";

        private Dictionary<string, LevelStaticData> _levels;
        private Dictionary<EnemyTypeId, MonsterStaticData> _enemies;
        private Dictionary<WindowId, WindowConfigData> _windowConfigs;
        private Dictionary<string, EnemySpawnerData> _enemySpawnerData;

        public void Load()
        {
            _levels = Resources.LoadAll<LevelStaticData>(LEVELS_PATH)
                .ToDictionary(x => x.LevelKey, x => x);
            _enemies = Resources.LoadAll<MonsterStaticData>(MONSTERS_PATH)
                .ToDictionary(x => x.MonsterTypeId, x => x);
            _windowConfigs = Resources.Load<WindowsStaticData>(WINDOWS_PATH).Configs
                .ToDictionary(x => x.WindowId, x => x);
            _enemySpawnerData = Resources.Load<SpawnerStaticData>(SPAWNER_DATA).Config
                .ToDictionary(x => x.WaveId, x => x);
        }

        public MonsterStaticData ForMonster(EnemyTypeId type) =>
            _enemies.TryGetValue(type, out MonsterStaticData data)
            ? data
            : null;

        public LevelStaticData ForLevel(string sceneKey) =>
            _levels.TryGetValue(sceneKey, out LevelStaticData data)
            ? data
            : null;

        public WindowConfigData ForWindow(WindowId windowId) =>
           _windowConfigs.TryGetValue(windowId, out WindowConfigData data)
         ? data
         : null;

        public EnemySpawnerData ForSpawner(string waveId) =>
            _enemySpawnerData.TryGetValue(waveId, out EnemySpawnerData data)
         ? data
         : null;

    }
}