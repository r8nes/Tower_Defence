using UnityEngine;

namespace Defender.Entity
{
    public class EnemyHit : MonoBehaviour
    {
        public float Damage = 1f;
        public EnemyMovement EnemyMovement;

        private void Start()
        {
           // EnemyMovement.OnPlayerTriggered += OnMinimalDistance;
        }

        private void OnMinimalDistance()
        {
            if (EnemyMovement.IsReachPlayer())
            {

            }
        }
    }
}
