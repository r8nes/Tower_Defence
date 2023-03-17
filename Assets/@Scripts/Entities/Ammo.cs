using UnityEngine;

namespace Defender.Entity
{
    public class Ammo : MonoBehaviour, IAmmo
    {
        private Rigidbody2D objectRigidbody;
        
        public int Damage = 5;
        public float Speed = 5f;

        public void Construct(float speed,int damage) 
        {
            Speed = speed;
            Damage = damage;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IHealth health))
            {
                health.TakeDamage(2f);
            }
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            objectRigidbody = transform.GetComponent<Rigidbody2D>();
            objectRigidbody.velocity = transform.up * Speed;
        }
    }
}
