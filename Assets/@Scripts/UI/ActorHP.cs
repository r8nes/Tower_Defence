using Defender.Entity;
using UnityEngine;

namespace Defender.UI
{
    public class ActorHP : MonoBehaviour
    {
        [Header("HPBar")]
        public HpBar HpBar;

        private IHealth _health;

        private void Start()
        {
            IHealth health = GetComponent<IHealth>();

            if (health != null)
                Construct(health);

            UpdateHpBar();
        }

        private void OnDisable() => _health.HealthChanged -= UpdateHpBar;

        public void Construct(IHealth health)
        {
            _health = health;
            _health.HealthChanged += UpdateHpBar;
        }

        private void UpdateHpBar()
        {
            HpBar.SetBarValue(_health.Current, _health.Max);
            HpBar.SetTextValue(_health.Current, _health.Max);
        }
    }
}