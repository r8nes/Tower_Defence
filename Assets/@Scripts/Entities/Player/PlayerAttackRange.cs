using UnityEngine;

namespace Defender.Entity
{
    public class PlayerAttackRange : MonoBehaviour
    {
        public PlayerAttack Attack;

        private void Start()
        {
            Attack.DisableAttack();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Attack.EnableAttack(collision);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            Attack.DisableAttack();
        }
    }
}