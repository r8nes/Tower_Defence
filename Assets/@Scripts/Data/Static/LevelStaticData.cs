using System.Collections.Generic;
using Defender.Logic;
using UnityEngine;

namespace Defender.Data.Static
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "StaticData/Level")]
    public class LevelStaticData : ScriptableObject
    {
        public string LevelKey;
        public Vector2 InitialHeroPosition;

        public List<EnemySpawnerData> EnemySpawner;
    }
}
