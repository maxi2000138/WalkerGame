using System;
using System.Collections;
using UnityEngine;

public class AttackState : EnemyState
{
    private IHealth _playerHealth;
    private float _secondsBeetweenAttacks = 0f;
    private float _enemyDamage;
    private Coroutine _attackCoroutine;

    public override void Construct(EnemyStateMachine enemyStateMachine)
    {
        _enemyDamage = enemyStateMachine.EnemyStaticData.Damage;
        _secondsBeetweenAttacks = enemyStateMachine.EnemyStaticData.AttackDelay;
        _playerHealth = enemyStateMachine.Player.GetComponent<PlayerHealth>();
    }

    private void OnEnable()
    {
        _attackCoroutine = StartCoroutine(AttackCoroutine());
    }

    private void OnDisable()
    {
        StopCoroutine(_attackCoroutine);
    }

    IEnumerator AttackCoroutine()
    {
        while (true)
        {
            _playerHealth.TakeDamage(_enemyDamage);
            yield return new WaitForSeconds(_secondsBeetweenAttacks);
        }
    }
}
