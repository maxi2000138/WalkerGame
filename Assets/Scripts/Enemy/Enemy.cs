using Data.CustomStaticData;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        public EnemyStateMachine.EnemyStateMachine EnemyStateMachine { get; private set; }
        public EnemyMover EnemyMover { get; private set; }
    
        public void Construct(Player.Player player, EnemyStaticData staticData)
        {
            EnemyStateMachine = GetComponentInChildren<EnemyStateMachine.EnemyStateMachine>();
            EnemyMover = GetComponent<EnemyMover>();
        
            EnemyStateMachine.Construct(player, staticData);
            EnemyMover.Construct(player, staticData.Speed);
        }
    }
}
