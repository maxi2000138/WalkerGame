using Data.CustomStaticData;
using Infrastructure.Services;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        public EnemyStateMachine.EnemyStateMachine EnemyStateMachine { get; private set; }
        public EnemyMover EnemyMover { get; private set; }
        
        public LootSpawner LootSpawner { get; private set; }
    
        public void Construct(Player.Player player, EnemyStaticData staticData, GameFactory gameFactory)
        {
            EnemyStateMachine = GetComponentInChildren<EnemyStateMachine.EnemyStateMachine>();
            EnemyMover = GetComponent<EnemyMover>();
            LootSpawner = GetComponent<LootSpawner>();
            
            EnemyStateMachine.Construct(player, staticData);
            EnemyMover.Construct(player, staticData.Speed);
            LootSpawner.Construct(gameFactory);
        }
    }
}
