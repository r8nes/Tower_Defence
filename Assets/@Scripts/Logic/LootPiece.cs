using TMPro;
using UnityEngine;

namespace Defender.Logic
{
    public class LootPiece : MonoBehaviour
    {
        private const float DelayBeforeDestroying = 0.2f;

        public TextMeshProUGUI LootText;

        private Loot _loot;
        private WorldData _worldData;

        private void Start()
        {
            Pickup();
        }

        public void Construct(WorldData worldData) => _worldData = worldData;

        public void Initialize(Loot loot) => _loot = loot;

        private void Pickup()
        {
            UpdateWorldData();
            ShowText();

            Destroy(gameObject, DelayBeforeDestroying);
        }

        private void UpdateWorldData() => UpdateCollectedLootAmount();

        private void ShowText() => LootText.text = $"{_loot.Value}";

        private void UpdateCollectedLootAmount() =>
         _worldData.LootData.Collect(_loot);

    }
}