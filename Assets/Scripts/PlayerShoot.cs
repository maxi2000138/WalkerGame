using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPoint;
    private Config _config;

    public void Construct(Config config)
    {
        _config = config;
    }
    
    public void Shoot()
    {
        Bullet bullet = Instantiate(_bullet);
        bullet.Construct(_shootPoint.position, _shootPoint.rotation, _config);
    }
}