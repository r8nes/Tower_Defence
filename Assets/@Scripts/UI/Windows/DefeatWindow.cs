using TMPro;
using UnityEngine.SceneManagement;

namespace Defender.UI
{
    public class DefeatWindow : WindowBase
    {
        public TextMeshProUGUI ScoreText;

        protected override void OnAwake()
        {
            // Простая заглушка
            SceneManager.LoadScene(0);

            base.OnAwake();
        }

        protected override void Initialize() => RefreshText();

        protected override void SubScribeUpdates() => Progress.WorldData.LootData.Changed += RefreshText;

        protected override void CleanUp() => Progress.WorldData.LootData.Changed -= RefreshText;

        private void RefreshText() => ScoreText.text = Progress.WorldData.LootData.Collected.ToString();
    }
}