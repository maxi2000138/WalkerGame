using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private float _damage;
    private float _flyTime;
    private float _bulletSpeed;

    public void Construct(Vector2 position, Quaternion rotation, BulletStaticData bulletStaticData)
    {
        transform.position = position;
        transform.rotation = rotation;
        _damage = bulletStaticData.Damage;
        _flyTime = bulletStaticData.FlyTime;
        _bulletSpeed = bulletStaticData.Speed;
        
        StartCoroutine(DestroyCoroutine());
    }

    private void FixedUpdate()
    {
        Vector3 newPosition = transform.position + transform.up * (_bulletSpeed * Time.fixedDeltaTime);
        _rigidbody2D.MovePosition(newPosition);
    }

    IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(_flyTime);
        Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.TryGetComponent(out EnemyHealth health))
        {
            health.TakeDamage(_damage); 
            Destroy(gameObject);
        }
    }
}