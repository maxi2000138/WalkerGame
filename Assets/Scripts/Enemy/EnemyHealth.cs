using System;
using HP;
using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        private float _current;
        private float _max;

        public event Action HealthChanged;

        public float Current
        {
            get => _current;
            set => _current = value;
        }

        public float Max
        {
            get => _max;
            set => _max = value;
        }

        public void TakeDamage(float damage)
        {
            if (Current - damage <= 0)
            {
                Current = 0;
            
            }
        
            Current -= damage;
            HealthChanged?.Invoke();
        }

    }
}