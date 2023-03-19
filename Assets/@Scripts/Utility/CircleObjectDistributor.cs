using System.Collections.Generic;
using UnityEngine;

namespace Defender.Utility
{
    public class CircleObjectDistributor : MonoBehaviour
    {
        public float Radius = 5f;
        public List<Transform> Objects = new List<Transform>();

        private void OnValidate()
        {
            UpdateObjectPositions();
        }

        public void UpdateObjectPositions()
        {
            if (Objects.Count == 0)
            {
                return;
            }

            float angle = 360f / Objects.Count;
            float currentAngle = 0f;

            for (int i = 0; i < Objects.Count; i++)
            {
                Vector2 objectPosition = new Vector2(
                    Mathf.Cos(currentAngle * Mathf.Deg2Rad),
                    Mathf.Sin(currentAngle * Mathf.Deg2Rad)) * Radius;
                Objects[i].position = (Vector2)transform.position + objectPosition;
                currentAngle += angle;
            }
        }
    }
}
