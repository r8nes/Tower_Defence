using UnityEngine;

namespace Defender.Entity
{
    public class Ammo : MonoBehaviour, IAmmo
    {
        private float _damage;
        private float _speed;
        private float _distance;

        public Vector2 _startPosition;

        private GameObject _enemyGameObject;

        private void Start()
        {
            _distance = Vector2.Distance(_startPosition, _enemyGameObject.transform.position);
        }

        private void Update()
        {
            MoveAmmo();
        }

        private void MoveAmmo()
        {
            if (_enemyGameObject != null)
            {
                gameObject.transform.position = Vector3.MoveTowards(transform.position, _enemyGameObject.transform.position, Time.deltaTime * _speed / _distance);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void Construct(float speed, float damage, GameObject target)
        {
            _speed = speed;
            _damage = damage;
            _enemyGameObject = target;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IHealth health))
                health.TakeDamage(_damage);

            Destroy(gameObject);
        }
    }
}
