using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{

    [SerializeField] private EnemyMover _enemyMover;
    [SerializeField] private EnemyStaticData _enemyStaticData;
    [SerializeField] private EnemyState _firstState;

    private EnemyState _currentState;
    private Player _player;
    
    public EnemyMover EnemyMover => _enemyMover;
    public EnemyStaticData EnemyStaticData => _enemyStaticData;
    public Player Player => _player;


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
        if (nextState != null)
        {
            nextState.Construct(this);
            Transit(nextState);
        }
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
