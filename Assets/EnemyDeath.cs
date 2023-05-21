using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class EnemyDeath : MonoBehaviour
{
    private EnemyHealth _enemyHealth;

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
        if(_enemyHealth.Current <= 0)
            Destroy(gameObject);
    }
}
