using System;

namespace HP
{
    public interface IHealth
    {
        event Action HealthChanged;
        event Action HealthSeted;
        
        float Current { get; set; }
        float Max { get; set; }
        void TakeDamage(float damage);
    }
}