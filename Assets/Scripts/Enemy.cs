using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyStateMachine EnemyStateMachine { get; private set; }
    public EnemyMover EnemyMover { get; private set; }
    
    public void Construct(Player player, Config config)
    {
        EnemyStateMachine = GetComponentInChildren<EnemyStateMachine>();
        EnemyMover = GetComponent<EnemyMover>();
        
        EnemyStateMachine.Construct(player);
        EnemyMover.Construct(config, player);
    }
}
