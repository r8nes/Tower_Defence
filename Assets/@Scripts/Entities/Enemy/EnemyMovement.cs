using UnityEngine;

namespace Defender.Entity
{
    public class EnemyMovement : MonoBehaviour
    {
        private const float _minDistance = 0.1f;
        private float _speed;

        private Transform _playerTransform;

        public void Construct(Transform playerTransform)
        {
            _playerTransform = playerTransform;
        }

        public bool IsReachPlayer() => Vector3.Distance(transform.position, _playerTransform.position) >= _minDistance;

        private void Update()
        {
            if (_playerTransform && IsReachPlayer())
            {
                transform.position = Vector2.MoveTowards(transform.position, _playerTransform.transform.position, _speed * Time.deltaTime);
            }
        }
    }
}