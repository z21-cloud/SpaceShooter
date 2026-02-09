using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpaceShooter.Pooling;
using System;

namespace SpaceShooter.Enemies
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _damage = 25f;
        [SerializeField] private float _speed = 15f;
        [SerializeField] private float _lifetime = 5f;

        private float _currentLifetime;
        private BulletPool _pool;

        private void Update()
        {
            HandleMovement();
            Lifetimer();
        }

        private void HandleMovement()
        {

        }

        private void Lifetimer()
        {
            _currentLifetime += Time.deltaTime;
            if(_currentLifetime >= _lifetime)
            {
                ReturnToPool();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                Debug.Log(collision.gameObject.name);
                damageable.TakeDamage(_damage);
                ReturnToPool();
            }
        }

        private void ReturnToPool()
        {
            //return pool.Release(this);
        }
    }
}

