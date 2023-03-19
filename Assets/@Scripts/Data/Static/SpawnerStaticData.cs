using System.Collections.Generic;
using UnityEngine;

namespace Defender.Data.Static
{
    [CreateAssetMenu(fileName = "SpawnerData", menuName = "StaticData/Spawner")]
    public class SpawnerStaticData : BaseStaticData 
    {
        public List<EnemySpawnerData> Config;
    }
}
