using Defender.Logic;
using TMPro;
using UnityEngine;

namespace Defender.UI
{
    public class LootCounter : MonoBehaviour
    {
        private WorldData _worldData;
        public TextMeshProUGUI Counter;

        public void Construct(WorldData worldData)
        {
            _worldData = worldData;
            _worldData.LootData.Changed += UpdatedCounter;
        }

        private void Start()
        {
            UpdatedCounter();
        }

        private void UpdatedCounter() => Counter.text = $"$ {_worldData.LootData.Collected}";
    }
}
