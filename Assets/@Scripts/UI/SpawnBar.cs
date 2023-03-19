using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Defender.UI
{
    public class SpawnBar : MonoBehaviour 
    {
        public Image Image;
        public TextMeshProUGUI EnemiesCount;
        public TextMeshProUGUI WaveText;

        public void SetBarValue(float current, float max) => Image.fillAmount =  current / max;
        public void SetEnemiesTextValue(float current, float max) => EnemiesCount.text = $"{current} / {max}";
        public void SetWaveTextValue(float current) => WaveText.text = $"WAVE: {current}";
    }
}