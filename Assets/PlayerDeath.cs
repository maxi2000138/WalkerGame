using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
public class PlayerDeath : MonoBehaviour
{
    private PlayerHealth _playerHealth;

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
        if(_playerHealth.Current <= 0)
            Destroy(gameObject);
    }
}
