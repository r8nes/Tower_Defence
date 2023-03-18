using UnityEngine;

namespace Defender.Entity
{
    public class EnemyHit : MonoBehaviour
    {
        public EnemyMovement EnemyMovement;

        private void Start()
        {
            EnemyMovement.OnPlayerTriggered += OnMinimalDistance;
        }

        private void OnMinimalDistance()
        {
            if (EnemyMovement.IsReachPlayer())
            {
                Debug.Log("Player Die");
            }
        }
    }
}
