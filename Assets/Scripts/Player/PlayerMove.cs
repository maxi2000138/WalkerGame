using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMove : MonoBehaviour
    {
        private Vector3 _position;
        private float _playerSpeed;
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Construct(float playerSpeed)
        {
            _playerSpeed = playerSpeed;
        }
    
        public void Move(Vector2 deltaPosition, float deltaTime)
        {
            Vector3 newPosition = new Vector2(transform.position.x, transform.position.y) + (deltaPosition * (_playerSpeed * deltaTime));
            _rigidbody2D.MovePosition(newPosition);
        }

    }
}