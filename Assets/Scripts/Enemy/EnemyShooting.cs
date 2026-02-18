using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpaceShooter.Shooting;
using SpaceShooter.Pooling;
using UnityEngine.Windows;
using SpaceShooter.Effects;

namespace SpaceShooter.Shooting
{
    public class EnemyShooting : MonoBehaviour
    {
        [SerializeField] private float timeBetweenShots = 1f;
        [SerializeField] private Transform shootPoint;
        [SerializeField] private Vector2 bulletDirection = Vector2.down;

        private float currentTimer = 0f;

        private IBulletProvider _bulletProvider;
        private IPoolReturn _poolReturn;
        private IEffectService _effectService;

        public void Construct(IBulletProvider bulletProvider, IPoolReturn poolReturn, IEffectService effectService)
        {
            _bulletProvider = bulletProvider;
            _poolReturn = poolReturn;
            _effectService = effectService;
        }

        private void Update()
        {
            currentTimer += Time.deltaTime;
            if (currentTimer >= timeBetweenShots)
            {
                HandleShooting();
                currentTimer = 0f;
            }
        }

        private void HandleShooting()
        {
            Bullet bullet = _bulletProvider.GetBullet();

            bullet.transform.position = shootPoint.position;
            bullet.transform.rotation = shootPoint.rotation;

            bullet.Initialize(_poolReturn, bulletDirection, _effectService);
        }
    }
}

