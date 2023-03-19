using System;
using System.Collections.Generic;
using Defender.Logic;
using UnityEngine;

namespace Defender.Data.Static
{
    [Serializable]
    public class EnemySpawnerData
    {
        public int WaveCount;
        public int EnemiesPerWave;

        public float Interval;
        public string WaveId;

        public EnemyTypeId MonsterTypeId;
        public Vector2 Position;
    }
}
