using System;
using System.Collections;
using UnityEngine;

namespace Defender.Entity
{
    public class EnemyDeath : MonoBehaviour
    {
        public EnemyHealth Health;
        public GameObject DeathFX;

        public event Action DeathHappend;

        private void Start() => Health.HealthChanged += OnHealthChanged;
        private void OnDestroy() => Health.HealthChanged -= OnHealthChanged;

        private void OnHealthChanged()
        {
            if (Health.Current <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Health.HealthChanged -= OnHealthChanged;

            SpawnDeathEffect();
            DeathHappend?.Invoke();
            StartCoroutine(DestroyTimer());
        }

        private void SpawnDeathEffect() => Instantiate(DeathFX, transform.position, Quaternion.identity);

        private IEnumerator DestroyTimer()
        {
            yield return new WaitForSeconds(0.1f);
            Destroy(gameObject);
        }
    }
}