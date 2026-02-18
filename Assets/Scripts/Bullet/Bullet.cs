using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpaceShooter.Pooling;
using System;
using SpaceShooter.Health;
using SpaceShooter.Effects;

namespace SpaceShooter.Shooting
{
    public class Bullet : MonoBehaviour
    {
        [Header("Bullet set-up")]
        [SerializeField] private float damage = 25f;
        [SerializeField] private float speed = 15f;
        [SerializeField] private float lifetime = 5f;

        private float currentLifetime;
        private Vector2 direction;
        private IPoolReturn pool;
        private IEffectService effectService;

        public void Initialize(IPoolReturn pool, Vector2 direction, IEffectService effectService)
        {
            this.pool = pool;
            this.direction = direction;
            this.effectService = effectService;
            currentLifetime = 0;
        }

        private void Update()
        {
            HandleMovement();
            Lifetimer();
        }

        private void HandleMovement()
        {
            transform.Translate(direction * speed * Time.deltaTime);
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

                effectService?.PlayHitEffect(transform.position);

                ReturnToPool();
            }
        }

        private void ReturnToPool()
        {
            pool.ReturnToPool(gameObject);
        }
    }
}

