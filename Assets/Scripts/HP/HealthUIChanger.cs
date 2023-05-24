using HP.View;
using UnityEngine;

namespace HP
{
    public class HealthUIChanger : MonoBehaviour
    {
        public HpBar HpBar;

        private IHealth _health;

        public void Construct(IHealth health)
        {
            _health = health;
            _health.HealthChanged += UpdateHpBar;
            _health.HealthSeted += UpdateHpBar;
        }

        private void OnDestroy()
        {
            _health.HealthChanged -= UpdateHpBar;
            _health.HealthSeted -= UpdateHpBar;
        }
    
        private void UpdateHpBar()
        {
            HpBar.SetValue(_health.Current, _health.Max);
        }
    }
}
