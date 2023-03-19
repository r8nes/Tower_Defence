using Defender.Data;
using Defender.Utility.EventBus;
using UnityEngine;

namespace Defender.Entity
{
    [RequireComponent(typeof(LineRenderer))]
    public class AggroZone : MonoBehaviour, IButtonHandler
    {
        public int Segments = 32;

        public PlayerAttack PlayerAttack;
        public CapsuleCollider2D CapsuleZone;

        private float _radius;

        private LineRenderer _lineRenderer;
        private PlayerProgress _playerProgress;

        private Color color = Color.white;

        public void Construct(PlayerProgress progress) 
        {
            _playerProgress = progress;
        }

        private void Start()
        {
            SetupLineRenderer();
            DrawCircle();
        }

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }
        
        // EventBus
        public void HandleButtonData(PlayerAttackData data)
        {
            DrawCircle();
        }

        private void DrawCircle()
        {
            _radius = _playerProgress.PlayerDamageData.DamageRadius;

            SetCirclePosition(out Vector3[] positions, out float angle, out float angleStep);

            CapsuleZone.size = new Vector2(_radius * 2, 0);
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

            for (int i = 0; i < Segments + 1; i++)
            {
                positions[i] = new Vector3(_radius * Mathf.Cos(angle), 0f, _radius * Mathf.Sin(angle));
                angle += angleStep;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerAttack.EnableAttack(collision);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            PlayerAttack.DisableAttack();
        }
    }
}
