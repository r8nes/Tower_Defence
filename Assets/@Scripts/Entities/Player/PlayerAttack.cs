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

        private Queue<GameObject> Enemies = new Queue<GameObject>();

        public PlayerAttackData AttackStats;
        public GameObject Ammo;

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
            if (Enemies.Count > 0)
            {
                var projectile = Instantiate(Ammo, transform);

                if (projectile != null )
                {
                    projectile.transform.SetPositionAndRotation(transform.position, transform.rotation);

                    var ammo = projectile.GetComponent<Ammo>();
                    ammo.Construct(
                        AttackStats.BulletSpeed,
                        AttackStats.Damage,
                        Enemies.Peek().transform.position);
                }
            }
        }

        public void EnableAttack(Collider2D enemy)
        {

            GameObject enemyGameObject = enemy.gameObject;

            var enemyDeathComponent = enemy.GetComponent<EnemyDeath>();
            enemyDeathComponent.DeathHappend += DisableAttack;

            Enemies.Enqueue(enemyGameObject);
            Debug.Log(Enemies.Count);

            _attackIsActive = true;
        }

        public void DisableAttack()
        {
            if (Enemies.Count <= 0)
                _attackIsActive = false;
            else
                Enemies.Dequeue();
        }

        public void LoadProgress(PlayerProgress progress) => AttackStats = progress.PlayerDamageData;
    }
}