using Defender.Data;
using Defender.Utility.EventBus;
using TMPro;
using UnityEngine;

namespace Defender.UI
{
    public class ActorButton : MonoBehaviour
    {
        public int MaxLevelUpgrade = 4;
        public int NumberToIncrement;

        public TextMeshProUGUI ParameterName;
        public PlayerAttackParameter PlayerParamter;

        private int _currentUpgrade = 1;

        private PlayerAttackData _playerProgress;

        public void Construct(PlayerProgress progress)
        {
            _playerProgress = progress.PlayerDamageData;
            SetStatText();
        }
        
        //EventBus
        public void UpgradeProgress()
        {
            if (_currentUpgrade <= MaxLevelUpgrade)
            {
                _playerProgress.SetParameter(PlayerParamter, NumberToIncrement);
                ParameterName.text = _playerProgress.GetParameter(PlayerParamter).ToString();

                EventBus.RaiseEvent<IButtonHandler>(h => h.HandleButtonData(_playerProgress));

                _currentUpgrade++;
            }
        }
        
        private void SetStatText()
        {
            ParameterName.text = _playerProgress.GetParameter(PlayerParamter).ToString();
        }
    }
}
