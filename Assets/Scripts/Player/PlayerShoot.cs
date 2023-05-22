using Data.CustomStaticData;
using UnityEngine;

namespace Player
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] private Bullet.Bullet _bullet;
        [SerializeField] private Transform _shootPoint;

        private BulletStaticData _bulletStaticData;
        public void Construct(BulletStaticData bulletStaticData)
        {
            _bulletStaticData = bulletStaticData;
        }
    
        public void Shoot()
        {
            Bullet.Bullet bullet = Instantiate(_bullet);
            bullet.Construct(_shootPoint.position, _shootPoint.rotation, _bulletStaticData);
        }
    }
}