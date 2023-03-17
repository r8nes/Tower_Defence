using System;
using Defender.Data;

namespace Defender.Logic
{
    [Serializable]
    public class WorldData
    {
        public LootData LootData;

        public WorldData()
        {
            LootData = new LootData();
        }
    }
}