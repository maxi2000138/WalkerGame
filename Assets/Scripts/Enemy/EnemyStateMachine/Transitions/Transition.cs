using Enemy.EnemyStateMachine.States;
using UnityEngine;

namespace Enemy.EnemyStateMachine.Transitions
{
    public abstract class Transition : MonoBehaviour
    {
    
    
        [SerializeField] private EnemyState _targetState;
    
        protected bool _needTransit;
    
        private Player.Player _target;

        public Player.Player Target => _target;
        public bool NeedTransit => _needTransit;
        public EnemyState TargetState => _targetState;
    
        public void Init(Player.Player target)
        {
            _target = target;
            _needTransit = false;
        }
    }
}
