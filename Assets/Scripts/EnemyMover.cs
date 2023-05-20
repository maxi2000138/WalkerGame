using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private Config _config;
    private Transform _playerTransform;
    
    public void Construct(Config config, Player player)
    {
        _config = config;
        _playerTransform = player.transform;
    }
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void MoveToPlayer(float deltaTime)
    {
        Vector2 pos = transform.position + (_playerTransform.position - transform.position).normalized *
            (_config.EnemySpeed * deltaTime);
        _rigidbody2D.MovePosition(pos);
    }
}
