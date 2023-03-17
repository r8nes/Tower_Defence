using System;
using Defender.Data;
using Defender.Service;
using Defender.Utility;
using UnityEngine;

namespace Defender.Entity
{
    public class PlayerAttack : MonoBehaviour, ISavedProgressReader
    {
        private bool _attackIsActive;
        public PlayerAttackData AttackStats;

        private void Update()
        {
            if (_attackIsActive)
            {
                PlayAttack();
            }
        }

        private void PlayAttack()
        {
            GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject();
            if (bullet != null)
            {
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;

                bullet.SetActive(true);
            }
        }

        public void EnableAttack() => _attackIsActive = true;

        public void DisableAttack() => _attackIsActive = false;

        public void LoadProgress(PlayerProgress progress) => AttackStats = progress.PlayerDamageData;
    }
}