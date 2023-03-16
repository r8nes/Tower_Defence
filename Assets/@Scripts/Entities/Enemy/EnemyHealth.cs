using System;
using UnityEngine;

namespace Defender.Entity
{
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private float _max;
        [SerializeField] private float _current;

        public float Max { get => _max; set => _max = value; }
        public float Current { get => _current; set => _current = value; }

        public event Action HealthChanged;

        public void TakeDamage(float damage)
        {
            Current -= damage;

            HealthChanged?.Invoke();
        }
    }
}
