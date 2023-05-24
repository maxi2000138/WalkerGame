using System;
using GameOver;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerHealth))]
    public class PlayerDeath : MonoBehaviour
    {
        private PlayerHealth _playerHealth;
        private GameOverPopup _gameOverPopup;

        public event Action Happened;


        public void Construct(GameOverPopup gameOverPopup)
        {
            _gameOverPopup = gameOverPopup;
        }
        private void Awake()
        {
            _playerHealth = GetComponent<PlayerHealth>();
        }

        private void OnEnable()
        {
            _playerHealth.HealthChanged += OnHealthChanged;
        }


        private void OnDisable()
        {
            _playerHealth.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            if (_playerHealth.Current <= 0)
            {
                Happened?.Invoke();
                _gameOverPopup.Show();
                Destroy(gameObject);
            }
        }
    }
}
