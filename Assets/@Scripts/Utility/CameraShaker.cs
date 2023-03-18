using System.Collections;
using UnityEngine;

namespace Defender.Utility
{
    public class CameraShaker : MonoBehaviour
    {
        public static CameraShaker CameraShakeInstance;

        private void Awake() => CameraShakeInstance = this;

        public void ShakeCamera(float duration, float magnitude, float noize)
        {
            StartCoroutine(ShakeCameraCor(duration, magnitude, noize));
        }

        private IEnumerator ShakeCameraCor(float duration, float magnitude, float noize)
        {
            float elapsed = 0f;

            Vector3 startPosition = transform.localPosition;
            Vector2 noizeStartPoint0 = Random.insideUnitCircle * noize;
            Vector2 noizeStartPoint1 = Random.insideUnitCircle * noize;

            while (elapsed < duration)
            {
                Vector2 currentNoizePoint0 = Vector2.Lerp(noizeStartPoint0, Vector2.zero, elapsed / duration);
                Vector2 currentNoizePoint1 = Vector2.Lerp(noizeStartPoint1, Vector2.zero, elapsed / duration);
                Vector2 cameraPostionDelta = new Vector2(
                    Mathf.PerlinNoise(currentNoizePoint0.x, currentNoizePoint0.y), 
                    Mathf.PerlinNoise(currentNoizePoint1.x, currentNoizePoint1.y));

                cameraPostionDelta *= magnitude;

                transform.localPosition = startPosition + (Vector3)cameraPostionDelta;

                elapsed += Time.deltaTime;
                yield return null;
            }
            transform.localPosition = startPosition;
        }
    }
}