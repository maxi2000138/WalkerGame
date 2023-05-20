using System;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class MoveState : EnemyState
{
    private EnemyMover _enemyMover;
    
    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
    }

    private void FixedUpdate()
    {
        _enemyMover.MoveToPlayer(Time.fixedDeltaTime);
    }
}
