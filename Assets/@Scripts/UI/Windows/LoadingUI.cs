using System.Collections;
using UnityEngine;

namespace Defender.System
{
    public class LoadingUI : MonoBehaviour
    {
        public float CanvasFadeSpeed = 0.03f;

        public CanvasGroup CanvasGroup;

        private void Awake()
        {   
            DontDestroyOnLoad(this);
        }

        public void ShowLoader()
        {
            gameObject.SetActive(true);
            CanvasGroup.alpha = 1;
        }

        public void HideLoader()
        {
            StartCoroutine(FadeIn());
        }

        private IEnumerator FadeIn()
        {
            while (CanvasGroup.alpha > 0)
            {
                CanvasGroup.alpha -= CanvasFadeSpeed;
                yield return new WaitForSeconds(0.03f);
            }

            gameObject.SetActive(false);
        }
    }
}
