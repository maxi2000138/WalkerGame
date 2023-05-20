using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    private Config _config;
    private Vector3 _position;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Construct(Config config)
    {
        _config = config;
    }
    
    public void Move(Vector2 deltaPosition, float deltaTime)
    {
        Vector3 newPosition = new Vector2(transform.position.x, transform.position.y) + (deltaPosition * (_config.PlayerSpeed * deltaTime));
        _rigidbody2D.MovePosition(newPosition);
    }

}