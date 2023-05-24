using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerHealth))]
    public class PlayerDeath : MonoBehaviour
    {
        private PlayerHealth _playerHealth;
        private GameOverPopup _gameOverPopup;


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
                _gameOverPopup.Show();
                Destroy(gameObject);
            }
        }
    }
}
