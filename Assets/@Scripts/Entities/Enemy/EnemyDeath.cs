using System;
using Defender.Utility;
using UnityEngine;

namespace Defender.Entity
{
    public class EnemyDeath : MonoBehaviour
    {
        public EnemyHealth Health;
        public EnemyMovement Movement;

        public GameObject DeathFX;

        public ShakeCameraData ShakeData;
        public event Action DeathHappend;

        private void Start()
        {
            Health.HealthChanged += OnHealthChanged;
            Movement.OnPlayerTriggered += Die;
        }

        private void OnDestroy()
        {
            Health.HealthChanged -= OnHealthChanged;
            Movement.OnPlayerTriggered -= Die;
        }

        public void Die()
        {
            SpawnDeathEffect();
            DeathHappend?.Invoke();

            Destroy(gameObject);
        }

        private void OnHealthChanged()
        {
            if (Health.Current <= 0)
            {
                Die();
            }
        }

        private void SpawnDeathEffect()
        {
            Instantiate(DeathFX, transform.position, Quaternion.identity);

            CameraShaker.CameraShakeInstance.ShakeCamera(
                ShakeData.Duration, 
                ShakeData.Magnitude,
                ShakeData.Noize);
        }
    }
}