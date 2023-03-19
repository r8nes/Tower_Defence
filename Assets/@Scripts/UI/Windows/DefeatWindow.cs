using Defender.State;
using TMPro;

namespace Defender.UI
{
    public class DefeatWindow : WindowBase
    {
        public TextMeshProUGUI ScoreText;
        public string TransferTo = "Main";

        protected override void OnAwake()
        {
            // заглушка
            CloseButton.onClick.AddListener(() => _stateMachine.Enter<BootstrapState>());
            base.OnAwake();
        }

        protected override void Initialize() => RefreshText();

        protected override void SubScribeUpdates() => Progress.WorldData.LootData.Changed += RefreshText;

        protected override void CleanUp() => Progress.WorldData.LootData.Changed -= RefreshText;

        private void RefreshText() => ScoreText.text = Progress.WorldData.LootData.Collected.ToString();
    }
}