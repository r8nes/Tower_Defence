using UnityEngine;

namespace Defender.Entity
{
    public class Ammo : MonoBehaviour, IAmmo
    {

        private int _damage = 5;
        private float _speed = 5f;

        private float _distance;
        private float _startTime;

        public Vector2 _startPosition;
        public Vector2 _targetPosition;

        public GameObject EnemyTransform;

        private void Start()
        {
            _distance = Vector2.Distance(_startPosition, _targetPosition);
        }

        private void Update()
        {
            float timeInterval = Time.time - _startTime;
            gameObject.transform.position = Vector3.Lerp(transform.position, _targetPosition, timeInterval * _speed / _distance);
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
            gameObject.SetActive(false);
        }
    }
}
