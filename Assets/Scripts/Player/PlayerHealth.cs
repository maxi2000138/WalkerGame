using System;
using Data.DataStructures;
using HP;
using Services;
using UnityEngine;

namespace Player
{
    public class PlayerHealth : MonoBehaviour, IHealth, ISavedProgress
    {
        private State _state = new State();

        public event Action HealthChanged;
        public event Action HealthSeted;

        public float Current
        {
            get => _state.CurrentHP;
            set
            {
                if (value != _state.CurrentHP)
                {
                    _state.CurrentHP = value;
          
                    HealthChanged?.Invoke();
                }
            }
        }

        public float Max
        {
            get => _state.MaxHP;
            set => _state.MaxHP = value;
        }


        public void LoadProgress(PlayerProgress progress)
        {
            if (progress.HeroState.CurrentHP != 0 && progress.HeroState.MaxHP != 0)
            {
                _state = progress.HeroState;
            }
            HealthSeted?.Invoke();
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            if (progress != null)
            {
                progress.HeroState.CurrentHP = Current;
                progress.HeroState.MaxHP = Max;
            }
        }

        public void TakeDamage(float damage)
        {
            if(Current <= 0)
                return;
      
            Current -= damage;
        }
    }
}
