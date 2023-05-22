using System.Collections.Generic;
using Enemy.EnemyStateMachine.Transitions;
using UnityEngine;

namespace Enemy.EnemyStateMachine.States
{
    public abstract class EnemyState : MonoBehaviour
    {
        [SerializeField] private List<Transition> _transitions;

        public abstract void Construct(EnemyStateMachine enemyStateMachine);

        public void Enter(Player.Player target)
        {
            if (enabled == false)
            {
                enabled = true;
                foreach (Transition transition in _transitions)
                {
                    transition.enabled = true;
                    transition.Init(target);
                }
            }
        }

        public void Exit()
        {
            if (enabled)
            {
                foreach (Transition transition in _transitions) 
                    transition.enabled = false;
                enabled = false;
            }
        }

        public EnemyState GetState()
        {
            foreach (Transition transition in _transitions)
            {
                if (transition.NeedTransit)
                    return transition.TargetState;
            }

            return null;
        }
    }
}
