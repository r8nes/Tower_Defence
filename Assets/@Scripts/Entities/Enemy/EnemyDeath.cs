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
            Movement.OnPlayerTriggered += OnPlayerColliding;
        }
        private void OnDestroy()
        {
            Health.HealthChanged -= OnHealthChanged;
            Movement.OnPlayerTriggered -= OnPlayerColliding;
        }

        public void DestroyEnemy()
        {
            SpawnDeathEffect();
            DeathHappend?.Invoke();

            Destroy(gameObject);
        }
        private void OnHealthChanged()
        {
            if (Health.Current <= 0)
            {
                DestroyEnemy();
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
        private void OnPlayerColliding(Transform player)
        {
            if (player.TryGetComponent(out IHealth health))
            {
                health.TakeDamage(1f);
            }

            DestroyEnemy();
        }
    }
}