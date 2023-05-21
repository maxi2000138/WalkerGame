using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyStateMachine EnemyStateMachine { get; private set; }
    public EnemyMover EnemyMover { get; private set; }
    
    public void Construct(Player player, EnemyStaticData staticData)
    {
        EnemyStateMachine = GetComponentInChildren<EnemyStateMachine>();
        EnemyMover = GetComponent<EnemyMover>();
        
        EnemyStateMachine.Construct(player);
        EnemyMover.Construct(player, staticData.Speed);
    }
}
