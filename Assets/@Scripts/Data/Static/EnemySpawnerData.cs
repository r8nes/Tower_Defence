using System;
using UnityEngine;

namespace Defender.Data.Static
{
    [Serializable]
    public class EnemySpawnerData
    {
        public string Id;

        public EnemyTypeId MonsterTypeId;
        public Vector2 Position;

        public int WaveCount;
        public float WaveDelay;

        public EnemySpawnerData(string id, EnemyTypeId monsterTypeId, Vector2 position, int waveCount, float waveDelay)
        {
            Id = id;
            MonsterTypeId = monsterTypeId;
            Position = position;
            WaveCount = waveCount;
            WaveDelay = waveDelay;
        }
    }
}
