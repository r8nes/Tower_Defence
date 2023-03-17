using System.Collections.Generic;
using System.Linq;
using Defender.Data;
using Defender.Data.Static;
using Defender.Service;
using UnityEngine;

public class StaticDataService : IStaticDataService
{
    private const string MONSTERS_PATH = "Data/Enemies";
    private const string LEVELS_PATH = "Data/Levels";

    private Dictionary<EnemyTypeId, MonsterStaticData> _enemies;
    private Dictionary<string, LevelStaticData> _levels;

    public void LoadMonsters()
    {
        _enemies = Resources.LoadAll<MonsterStaticData>(MONSTERS_PATH).ToDictionary(x => x.MonsterTypeId, x => x);

        _levels = Resources.LoadAll<LevelStaticData>(LEVELS_PATH).ToDictionary(x => x.LevelKey, x => x);
    }

    public MonsterStaticData ForMonster(EnemyTypeId type) =>
        _enemies.TryGetValue(type, out MonsterStaticData data)
        ? data
        : null;

    public LevelStaticData ForLevel(string sceneKey) =>
        _levels.TryGetValue(sceneKey, out LevelStaticData data)
        ? data
        : null;
}