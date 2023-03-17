using System;

namespace Defender.Data
{
    [Serializable]
    public class PlayerAttackData
    {
        public int Damage;
        public float DamageRadius;

        public float BulletSpeed;
        public float FireRate;
    }
}
