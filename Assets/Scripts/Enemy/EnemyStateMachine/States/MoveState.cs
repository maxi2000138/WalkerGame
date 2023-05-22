using UnityEngine;

namespace Enemy.EnemyStateMachine.States
{
    public class MoveState : EnemyState
    {
        private EnemyMover _enemyMover;


        public override void Construct(EnemyStateMachine enemyStateMachine)
        {
            _enemyMover = enemyStateMachine.EnemyMover;
        }

        private void FixedUpdate()
        {
            _enemyMover.MoveToPlayer(Time.fixedDeltaTime);
        }
    }
}
