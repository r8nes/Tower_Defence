using UnityEngine;

namespace Defender.Entity
{
    public class Ammo : MonoBehaviour, IAmmo
    {
        private int _damage;
        private float _speed;
        private float _distance;
  
        public Vector2 _startPosition;
        public Vector2 _targetPosition;

        public GameObject EnemyTransform;

        private void Start()
        {
            _distance = Vector2.Distance(_startPosition, _targetPosition);
        }

        private void Update()
        {
            gameObject.transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime *_speed / _distance);
        }

        public void Construct(float speed, int damage, Vector2 target)
        {
            _speed = speed;
            _damage = damage;
            _targetPosition = target;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IHealth health))
            {
                health.TakeDamage(_damage);
            }

            Destroy(gameObject);
        }
    }
}
