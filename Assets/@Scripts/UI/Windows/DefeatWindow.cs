using Defender.State;
using TMPro;
using UnityEngine;

namespace Defender.UI
{
    public class DefeatWindow : WindowBase
    {
        public TextMeshProUGUI ScoreText;

        protected override void OnAwake()
        {
            CloseButton.onClick.AddListener(() => {
               //HACK
                Time.timeScale = 1;
                _stateMachine.Enter<BootstrapState>();
            });
            base.OnAwake();
        }

        protected override void Initialize()
        {
            //HACK
            Time.timeScale = 0;

            RefreshText();
        }

        protected override void SubScribeUpdates() => Progress.WorldData.LootData.Changed += RefreshText;

        protected override void CleanUp() => Progress.WorldData.LootData.Changed -= RefreshText;

        private void RefreshText() => ScoreText.text = $"Your score: {Progress.WorldData.LootData.Collected}\n=3";
    }
}