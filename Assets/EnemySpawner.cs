using Data.TypeIds;
using DebugFeatures;
using Infrastructure.Services;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float sizeY = 1f;
    [SerializeField] private float sizeX = 1f;
    [SerializeField] private int _enemyAmount = 3;
    private GameFactory _gameFactory;


    public void Construct(GameFactory gameFactory)
    {
        _gameFactory = gameFactory;
    }
    private void Start()
    {
        for (int i = 0; i < _enemyAmount; i++)
        {
            _gameFactory.CreateEnemy(GetSpawnPoint(), EnemyTypeId.zombie);
        }
    }

    private void FixedUpdate()
    {
        PhysicsDebug.DrawBox(transform.position, sizeX, sizeY, 1/50f);
    }

    public Vector2 GetSpawnPoint()
    {
        return new Vector2(
            Random.Range(transform.position.x - sizeX / 2, transform.position.x + sizeX / 2),
            Random.Range(transform.position.y - sizeY / 2, transform.position.y + sizeY / 2)
        );
    }
}
