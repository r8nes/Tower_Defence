using System;

namespace Defender.Data
{
    [Serializable]
    public class PlayerAttackData
    {
        public float Damage;
        public float DamageRadius;

        public float BulletSpeed;
        public float FireRate;

        public void SetParameter(PlayerAttackParamter parameterType, int value)
        {
            switch (parameterType)
            {
                case PlayerAttackParamter.DAMAGE:
                    Damage += value;
                    break;
                case PlayerAttackParamter.DAMAGE_RADIUS:
                    DamageRadius += value;
                    break;
                case PlayerAttackParamter.BULLET_SPEED:
                    BulletSpeed += value;
                    break;
                case PlayerAttackParamter.FIRE_RATE:
                    FireRate += value;
                    break;
                default:
                    throw new Exception($"{parameterType} is illegal");
            }
        }

        public float GetParameter(PlayerAttackParamter parameterType)
        {
            return parameterType switch
            {
                PlayerAttackParamter.DAMAGE => Damage,
                PlayerAttackParamter.DAMAGE_RADIUS => DamageRadius,
                PlayerAttackParamter.BULLET_SPEED => BulletSpeed,
                PlayerAttackParamter.FIRE_RATE => FireRate,
                _ => throw new Exception($"{parameterType} is illegal"),
            };
        }
    }

    public enum PlayerAttackParamter 
    {
        DAMAGE = 0,
        DAMAGE_RADIUS = 1,
        BULLET_SPEED = 2,
        FIRE_RATE = 3
    }
}
