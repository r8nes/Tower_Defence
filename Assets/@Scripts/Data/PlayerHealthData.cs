using System;

namespace Defender.Data
{
    [Serializable]
    public class PlayerHealthData
    {
        public float CurrentHP;
        public float MaxHP;

        public void ResetCurrentHP() => CurrentHP = MaxHP;
    }
}