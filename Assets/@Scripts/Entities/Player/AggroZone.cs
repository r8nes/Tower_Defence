using Defender.Data;
using Defender.Service;
using UnityEngine;

namespace Defender.Entity
{
    [RequireComponent(typeof(LineRenderer))]
    public class AggroZone : MonoBehaviour
    {
        public int Segments = 32;

        public CircleCollider2D CircleCollider;
        public PlayerAttack PlayerAttack;

        private ProgressService _playerProgress;
        private LineRenderer _lineRenderer;

        private Color color = Color.white;

        public void Construct(ProgressService progress) 
        {
            _playerProgress = progress;
        }

        private void Start()
        {
            var radius = _playerProgress.Progress.PlayerDamageData.DamageRadius;

            SetupLineRenderer();
            SetCirclePosition(out Vector3[] positions, out float angle, out float angleStep);

            for (int i = 0; i < Segments + 1; i++)
            {
                positions[i] = new Vector3(radius * Mathf.Cos(angle), 0f, radius * Mathf.Sin(angle));
                angle += angleStep;
            }

            _lineRenderer.SetPositions(positions);
        }

        private void SetupLineRenderer()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _lineRenderer.positionCount = Segments + 1;
            _lineRenderer.useWorldSpace = false;
            _lineRenderer.startWidth = 0.05f;
            _lineRenderer.endWidth = 0.05f;
            _lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
            _lineRenderer.material.color = color;
        }
        
        private void SetCirclePosition(out Vector3[] positions, out float angle, out float angleStep)
        {
            positions = new Vector3[Segments + 1];
            angle = 0f;
            angleStep = 2f * Mathf.PI / Segments;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerAttack.EnableAttack(collision);
        }
    }
}
