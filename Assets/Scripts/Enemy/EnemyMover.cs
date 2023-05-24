using UnityEngine;

namespace Enemy
{
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;

        private Transform _playerTransform;
        private float _enemySpeed;
    
        public void Construct(Player.Player player, float enemySpeed)
        {
            _playerTransform = player.transform;
            _enemySpeed = enemySpeed;
        }
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void MoveToPlayer(float deltaTime)
        {
            if(_playerTransform == null)
                return;
            
            Vector2 pos = transform.position + (_playerTransform.position - transform.position).normalized *
                (_enemySpeed * deltaTime);
            _rigidbody2D.MovePosition(pos);
        }
    }
}
