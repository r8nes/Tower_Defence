﻿using System;
using Defender.Logic;

namespace Defender.Data
{
    [Serializable]
    public class LootData
    {
        public int Collected;

        public Action Changed;

        public void Collect(Loot loot)
        {
            Collected += loot.Value;
            Changed?.Invoke();
        }

        public void Add(int lootValue)
        {
            Collected += lootValue;
            Changed?.Invoke();
        }
    }
}