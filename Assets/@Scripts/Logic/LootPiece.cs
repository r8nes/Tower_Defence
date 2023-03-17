using TMPro;
using UnityEngine;

namespace Defender.Logic
{
    public class LootPiece : MonoBehaviour
    {
        public GameObject Loot;
        public GameObject PickupFixPrefab;
        public TextMeshPro LootText;
        public GameObject PickupPopup;

        private bool _picked;

        private Loot _loot;
        private WorldData _worldData;

        private const float DelayBeforeDestroying = 0.2f;

        public void Construct(WorldData worldData) => _worldData = worldData;

        public void Initialize(Loot loot) => _loot = loot;

        private void OnTriggerEnter(Collider other)
        {
            if (!_picked)
            {
                _picked = true;
                Pickup();
            }
        }

        private void Pickup()
        {
            UpdateWorldData();
            HideLoot();
            PlayPickupFx();
            ShowText();

            Destroy(gameObject, DelayBeforeDestroying);
        }

        private void UpdateWorldData()
        {
            UpdateCollectedLootAmount();
        }

        private void UpdateCollectedLootAmount() =>
         _worldData.LootData.Collect(_loot);

        private void PlayPickupFx()
        {
            Instantiate(PickupFixPrefab, transform.position, Quaternion.identity);
        }

        private void HideLoot()
        {
            Loot.SetActive(false);
        }

        private void ShowText()
        {
            LootText.text = $"{_loot.Value}";
            PickupPopup.SetActive(true);
        }
    }
}