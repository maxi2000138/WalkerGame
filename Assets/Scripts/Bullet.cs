using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private float _damage;
    private float _flyTime;
    private Config _config;

    public void Construct(Vector2 position, Quaternion rotation, Config config)
    {
        _config = config;
        transform.position = position;
        transform.rotation = rotation;
        _damage = _config.PlayerDamage;
        _flyTime = _config.BulletFlyTime;

        StartCoroutine(DestroyCoroutine());
    }

    private void FixedUpdate()
    {
        Vector3 newPosition = transform.position + transform.up * (_config.BulletSpeed * Time.fixedDeltaTime);
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