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

        public void SetParameter(PlayerAttackParameter parameterType, float value)
        {
            switch (parameterType)
            {
                case PlayerAttackParameter.DAMAGE:
                    Damage += value;
                    break;
                case PlayerAttackParameter.DAMAGE_RADIUS:
                    DamageRadius += value;
                    break;
                case PlayerAttackParameter.BULLET_SPEED:
                    BulletSpeed += value;
                    break;
                case PlayerAttackParameter.FIRE_RATE:
                    FireRate += value;
                    break;
                default:
                    throw new Exception($"{parameterType} is illegal");
            }
        }

        public float GetParameter(PlayerAttackParameter parameterType)
        {
            return parameterType switch
            {
                PlayerAttackParameter.DAMAGE => Damage,
                PlayerAttackParameter.DAMAGE_RADIUS => DamageRadius,
                PlayerAttackParameter.BULLET_SPEED => BulletSpeed,
                PlayerAttackParameter.FIRE_RATE => FireRate,
                _ => throw new Exception($"{parameterType} is illegal"),
            };
        }
    }

    public enum PlayerAttackParameter 
    {
        DAMAGE = 0,
        DAMAGE_RADIUS = 1,
        BULLET_SPEED = 2,
        FIRE_RATE = 3
    }
}
