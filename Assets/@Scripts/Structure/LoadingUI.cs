using System.Collections;
using UnityEngine;

namespace Defender.Logic
{
    public class LoadingUI : MonoBehaviour
    {
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
                CanvasGroup.alpha -= 0.03f;
                yield return new WaitForSeconds(0.03f);
            }

            gameObject.SetActive(false);
        }
    }
}
