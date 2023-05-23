using DebugFeatures;
using UnityEngine;

namespace Player
{
    public class PlayerGunRotater : MonoBehaviour
    {
        [SerializeField] private GameObject _gun;
        
        private float _circleRadius;
        private int layerMask;
        private bool _isEnemyNear = false;
        private Transform _enemy;
        private Collider2D[] _colliders;

        public void Construct(float radius)
        {
            _circleRadius = radius;
        }
        
        private void Awake()
        {
            layerMask = 1 << LayerMask.NameToLayer("Hittable");
            _colliders = new Collider2D[10];
        }

        private void FixedUpdate()
        {
            PhysicsDebug.DrawDebug(transform.position, _circleRadius,1/50f);
            
            int amount = Physics2D.OverlapCircleNonAlloc(transform.position, _circleRadius, _colliders, layerMask);
            if (amount == 0)
            {
                _isEnemyNear = false;
                return;
            }
            
            if (_enemy == null)
            {
                _enemy = _colliders[0].transform;
                return;
            }
            
            for(int i = 0; i < amount; i++)
            {
                if(Vector2.Distance(transform.position, _colliders[i].transform.position) 
                   < Vector2.Distance(transform.position, _enemy.transform.position))
                {
                    _enemy = _colliders[i].transform;
                }
            }
            
            _isEnemyNear = true;
        }

        public void Rotate(Vector2 lookVector)
        {
            Vector2 curLookVector = lookVector;
            
            if (_isEnemyNear) 
                curLookVector = (_enemy.transform.position - transform.position).normalized;

            Vector3 rotatedVectorToTarget = Quaternion.Euler(0, 0, 90) * curLookVector;
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, rotatedVectorToTarget);
            _gun.transform.rotation = targetRotation;
        }
    }
}
