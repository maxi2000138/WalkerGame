using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    
    
    [SerializeField] private EnemyState _targetState;
    
    protected bool _needTransit;
    
    private Player _target;

    public Player Target => _target;
    public bool NeedTransit => _needTransit;
    public EnemyState TargetState => _targetState;
    
    public void Init(Player target)
    {
        _target = target;
        _needTransit = false;
    }
}
