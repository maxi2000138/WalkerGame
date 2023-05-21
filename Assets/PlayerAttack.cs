using System;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform _playerAttackPoint;
    [SerializeField] private float _attackRadius;
    [SerializeField] private int _damage;
    private Collider[] _hits = new Collider[3];
    private int _layerMask;

    private void Awake()
    {
        _layerMask = 1 << LayerMask.NameToLayer("Hittable");
        
    }

    public void Attack()
    {
        for (int i = 0; i < Hit(); ++i)
        {
            _hits[i].transform.parent.GetComponent<IHealth>().TakeDamage(_damage);
            PhysicsDebug.DrawDebug(_playerAttackPoint.position, _attackRadius, 2f);
        }
    }

    public int Hit() =>
        Physics.OverlapSphereNonAlloc(_playerAttackPoint.position, _attackRadius, _hits, _layerMask);
}
