using System;
using Defender.Data;
using Defender.Service;
using UnityEngine;

namespace Defender.Entity
{
    public class PlayerHealth : MonoBehaviour, ISavedProgress, IHealth
    {
        private PlayerHealthData _healthData;

        public event Action HealthChanged;

        public float Current
        {
            get => _healthData.CurrentHP;
            set
            {
                if (_healthData.CurrentHP != value)
                {
                    _healthData.CurrentHP = value;
                    HealthChanged?.Invoke();
                }
            }
        }

        public float Max
        {
            get => _healthData.MaxHP;
            set => _healthData.MaxHP = value;
        }

        public void LoadProgress(PlayerProgress progress)
        {
            _healthData = progress.PlayerHealthData;
            HealthChanged?.Invoke();
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.PlayerHealthData.CurrentHP = Current;
            progress.PlayerHealthData.MaxHP = Max;
        }

        public void TakeDamage(float damage)
        {
            if (Current <= 0) return;

            Current -= damage;
        }
    }
}
