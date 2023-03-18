using Defender.Data;
using TMPro;
using UnityEngine;

namespace Defender.UI
{
    public class ActorButton : MonoBehaviour
    {
        public int NumberToIncrement;

        public TextMeshProUGUI ParameterName;
        public PlayerAttackParamter PlayerParamter;

        private PlayerAttackData _playerProgress;

        public void Construct(PlayerProgress progress) 
        {
            _playerProgress = progress.PlayerDamageData;
            ParameterName.text = _playerProgress.GetParameter(PlayerParamter).ToString();
        }

        public void UpgradeProgress() 
        {
            _playerProgress.SetParameter(PlayerParamter, NumberToIncrement);
            ParameterName.text = _playerProgress.GetParameter(PlayerParamter).ToString();
        }
    }
}