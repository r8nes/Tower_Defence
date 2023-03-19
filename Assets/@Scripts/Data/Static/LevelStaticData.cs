using System.Collections.Generic;
using Defender.Logic;
using UnityEngine;

namespace Defender.Data.Static
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "StaticData/Level")]
    public class LevelStaticData : BaseStaticData
    {
        public string LevelKey;
        public Vector2 InitialHeroPosition;

        public List<SpawnerTransform> SpawnerTransform;
    }
}
