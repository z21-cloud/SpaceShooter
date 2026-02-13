using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpaceShooter.Pooling;
using System;
using SpaceShooter.Damageable;

namespace SpaceShooter.Shooting
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float damage = 25f;
        [SerializeField] private float speed = 15f;
        [SerializeField] private float lifetime = 5f;

        private float currentLifetime;
        private IPoolReturn pool;

        public void Initialize(IPoolReturn pool)
        {
            this.pool = pool;
            currentLifetime = 0;
        }

        private void Update()
        {
            HandleMovement();
            Lifetimer();
        }

        private void HandleMovement()
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        private void Lifetimer()
        {
            currentLifetime += Time.deltaTime;
            if(currentLifetime >= lifetime)
            {
                ReturnToPool();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                Debug.Log(collision.gameObject.name);
                damageable.TakeDamage(damage);
                ReturnToPool();
            }
        }

        private void ReturnToPool()
        {
            pool.ReturnToPool(gameObject);
        }
    }
}

