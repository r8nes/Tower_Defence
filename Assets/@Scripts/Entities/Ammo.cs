using UnityEngine;

namespace Defender.Entity
{
    public class Ammo : MonoBehaviour, IAmmo
    {
        private Rigidbody2D objectRigidbody;
        
        private int _damage = 5;
        private float _speed = 5f;

        public Transform EnemyTransform { get; set; }

        public void Construct(float speed, int damage) 
        {
            _speed = speed;
            _damage = damage;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IHealth health))
            {
                health.TakeDamage(_damage);
            }
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            objectRigidbody = transform.GetComponent<Rigidbody2D>();

            if (EnemyTransform != null)
            {
                objectRigidbody.velocity = EnemyTransform.position * _speed;
            }
        }
    }
}
