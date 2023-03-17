using System;
using Defender.Logic;

namespace Defender.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public WorldData WorldData;
        public PlayerHealthData PlayerHealthData;
        public PlayerAttackData PlayerDamageData;

        public PlayerProgress()
        {
            WorldData = new WorldData();
            PlayerHealthData = new PlayerHealthData();
            PlayerDamageData = new PlayerAttackData();
        }
    }
}