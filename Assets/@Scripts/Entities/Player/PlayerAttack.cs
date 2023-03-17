using System.Collections.Generic;
using Defender.Data;
using Defender.Service;
using Defender.Utility;
using UnityEngine;

namespace Defender.Entity
{
    public class PlayerAttack : MonoBehaviour, ISavedProgressReader
    {
        private float _time;
        private bool _attackIsActive;

        private List<EnemyHealth> Enemies = new List<EnemyHealth>();

        public PlayerAttackData AttackStats;

        private void Update()
        {
            _time += Time.deltaTime;

            float nextTimeToFire = 1 / AttackStats.FireRate;

            if (_time >= nextTimeToFire)
            {
                if (_attackIsActive)
                {
                    PlayAttack();
                    _time = 0;
                }
            }
        }

        private void PlayAttack()
        {
            GameObject projectile = ObjectPooler.SharedInstance.GetPooledObject();

            if (projectile != null && Enemies.Count > 0)
            {
                projectile.transform.SetPositionAndRotation(transform.position, transform.rotation);

                var ammo = projectile.GetComponent<Ammo>();
                ammo.Construct(AttackStats.BulletSpeed, AttackStats.Damage);
                ammo.EnemyTransform = Enemies[0].transform;

                projectile.SetActive(true);
            }
        }

        public void EnableAttack(Collider2D enemy)
        {
            var objectToFire = enemy.GetComponent<EnemyHealth>();
            Enemies.Add(objectToFire);

            _attackIsActive = true;
        }

        public void DisableAttack()
        {
            if (Enemies.Count > 0)
            {
                Enemies.RemoveAt(0);
            }
            _attackIsActive = false;
        }

        public void LoadProgress(PlayerProgress progress) => AttackStats = progress.PlayerDamageData;
    }
}