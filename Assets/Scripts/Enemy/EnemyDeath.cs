using System;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(EnemyHealth))]
    public class EnemyDeath : MonoBehaviour
    {
        private EnemyHealth _enemyHealth;

        public event Action Happened;

        private void Awake()
        {
            _enemyHealth = GetComponent<EnemyHealth>();
        }

        private void OnEnable()
        {
            _enemyHealth.HealthChanged += OnHealthChanged;
        }


        private void OnDisable()
        {
            _enemyHealth.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            if (_enemyHealth.Current <= 0)
            {
                Happened?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
