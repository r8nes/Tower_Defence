using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;

namespace Defender.Utility
{
    public class TypeWriterUtility : MonoBehaviour
    {
        [Range(0.01f, 0.1f)]
        public float TypingSpeed = 0.05f;
        public TMP_Text TextMeshProComponent;

        private string _originalText;
        private StringBuilder _currentText;

        private void Start()
        {
            _originalText = TextMeshProComponent.text;
            _currentText = new StringBuilder();
            StartCoroutine(UpdateText());
        }

        private IEnumerator UpdateText()
        {
            TextMeshProComponent.text = "";

            for (int i = 0; i <= _originalText.Length - 1; i++)
            {
                _currentText.Append(_originalText[i]);
                TextMeshProComponent.text = _currentText.ToString();
                yield return new WaitForSeconds(TypingSpeed);
            }
        }
    }
}