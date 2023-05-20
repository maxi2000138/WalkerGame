using Unity.VisualScripting;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private EnemyState _firstState;

    private EnemyState _currentState;
    private Player _player;


    public void Construct(Player player)
    {
        _player = player;
    }
    
    private void Start()
    {
        Reset(_firstState);
    }

    private void Update()
    {
        if(_currentState == null)
            return;

        EnemyState nextState = _currentState.GetState();
        if(nextState != null)
            Transit(nextState);
    }

    private void Reset(EnemyState startState)
    {
        _currentState = startState;

        if (_currentState != null)
            _currentState.Enter(_player);
    }

    private void Transit(EnemyState nextState)
    {
        if(_currentState != null)
            _currentState.Exit();
        _currentState = nextState;
        _currentState.Enter(_player);
    }
}
