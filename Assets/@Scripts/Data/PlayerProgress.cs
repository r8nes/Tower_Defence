using System;
using Defender.Logic;

namespace Defender.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public WorldData WorldData;

        public PlayerProgress()
        {
            WorldData = new WorldData();
        }
    }
}
