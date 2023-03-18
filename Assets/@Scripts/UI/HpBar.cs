using UnityEngine;
using UnityEngine.UI;

namespace Defender.Entity
{
    public class HpBar : MonoBehaviour
    {
        public Image Image;

        public void SetValue(float current, float max) => Image.fillAmount = current / max;
    }
}