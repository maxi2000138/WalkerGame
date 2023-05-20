using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private Config _config;

    public void Construct(Vector2 position, Quaternion rotation, Config config)
    {
        _config = config;
        transform.position = position;
        transform.rotation = rotation;
    }

    private void FixedUpdate()
    {
        Vector3 newPosition = transform.position + transform.up * (_config.BulletSpeed * Time.fixedDeltaTime);
        _rigidbody2D.MovePosition(newPosition);
    }
}