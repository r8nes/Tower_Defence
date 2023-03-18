using Defender.Data;
using Defender.Entity;
using Defender.Service;
using UnityEngine;

namespace Defender.UI
{
    public class ActorUI : MonoBehaviour
    {
        [Header("HPBar")]
        public HpBar HpBar;

        private IHealth _health;

        private void Start()
        {
            IHealth health = GetComponent<IHealth>();

            if (health != null)
                Construct(health);
        }

        public void Construct(IHealth health)
        {
            _health = health;
            _health.HealthChanged += UpdateHpBar;
        }

        private void UpdateHpBar()
        {
            HpBar.SetValue(_health.Current, _health.Max);
        }
    }
}