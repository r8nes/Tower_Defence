using System;
using Defender.Data;
using UnityEngine;

namespace Defender.Entity
{
    public class PlayerHealth : MonoBehaviour, IHealth
    {
        private PlayerHealthData _healthData;

        public event Action HealthChanged;

        public void Construct(PlayerProgress progress) 
        {
            _healthData = progress.PlayerHealthData;
            Current = _healthData.MaxHP;
        }

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

        public void TakeDamage(float damage)
        {
            if (Current <= 0) return;

            Current -= damage;
            Debug.Log($"{Max}/{Current}");
        }

        #region Unused ISaveProgress

        //public void LoadProgress(PlayerProgress progress)
        //{
        //    _healthData = progress.PlayerHealthData;
        //    HealthChanged?.Invoke();
        //}

        //public void UpdateProgress(PlayerProgress progress)
        //{
        //    progress.PlayerHealthData.CurrentHP = Current;
        //    progress.PlayerHealthData.MaxHP = Max;
        //}

        #endregion
    }
}
