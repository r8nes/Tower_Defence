using System;
using Defender.Logic;

namespace Defender.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public WorldData WorldData;
        public PlayerHealthData HealthData;
        public PlayerAttackData PlayerDamageData;

        public PlayerProgress()
        {
            WorldData = new WorldData();
            HealthData = new PlayerHealthData();
        }
    }
}