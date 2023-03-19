using System.Collections.Generic;
using Defender.Data;
using UnityEngine;

namespace Defender.Entity
{
    public class PlayerAttack : MonoBehaviour
    {
        private float _time;
        private bool _attackIsActive;

        private Queue<EnemyDeath> Enemies = new Queue<EnemyDeath>();

        public GameObject Ammo;
        private PlayerProgress _playerProgress;

        public void Construct(PlayerProgress progress) 
        {
            _playerProgress = progress;
        }

        private void Update()
        {
            _time += Time.deltaTime;

            float nextTimeToFire = 1 / _playerProgress.PlayerDamageData.FireRate;

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
            if (Enemies.Count > 0)
            {
                GameObject projectile = Instantiate(Ammo, transform);

                if (projectile != null)
                {
                    projectile.transform.SetPositionAndRotation(transform.position, transform.rotation);

                    Ammo ammo = projectile.GetComponent<Ammo>();
                  
                    ammo.Construct(
                        _playerProgress.PlayerDamageData.BulletSpeed,
                        _playerProgress.PlayerDamageData.Damage,
                        Enemies.Peek().gameObject);
                }
            }
        }

        public void EnableAttack(Collider2D enemy)
        {
            if (enemy.TryGetComponent(out EnemyDeath enemyDeathComponent))
            {
                Enemies.Enqueue(enemyDeathComponent);
                _attackIsActive = true;
            }
        }

        public void DisableAttack()
        {
            if (Enemies.Count <= 0)
                _attackIsActive = false;
            else 
            {
                Enemies.Dequeue();
            }
        }
    }
}