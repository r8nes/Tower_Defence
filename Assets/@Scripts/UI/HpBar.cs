using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Defender.UI
{
    public class HpBar : MonoBehaviour
    {
        public Image Image;
        public TextMeshProUGUI HpText;

        public void SetValue(float current, float max) => Image.fillAmount = current / max;
        public void SetTextValue(float current, float max) => HpText.text = $"{current} / {max}";
    }
}