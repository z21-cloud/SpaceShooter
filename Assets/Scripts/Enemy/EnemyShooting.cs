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
        [Header("Enemies shooting set-up")]
        [SerializeField] private float fireRate = 1f;
        [SerializeField] private float timerOffset = 0.2f;
        [SerializeField] private float minimumFireRate = 0.2f;
        [SerializeField] private Vector2 bulletDirection = Vector2.down;
        [SerializeField] private Transform shootPoint;

        private float timeBetweenShots = 0f;
        private float currentTimer = 0f;
        
        private IBulletProvider _bulletProvider;
        private IPoolReturn _poolReturn;

        public void Construct(IBulletProvider bulletProvider, IPoolReturn poolReturn)
        {
            _bulletProvider = bulletProvider;
            _poolReturn = poolReturn;
        }

        private void Update()
        {
            TimerBetweenShots();
            
            currentTimer += Time.deltaTime;
            if(currentTimer >= timeBetweenShots)
            {
                BulletInstantiating();
                currentTimer = 0f;
            }
        }

        private void TimerBetweenShots()
        {
            timeBetweenShots = Random.Range(fireRate - timerOffset, fireRate + timerOffset);
            timeBetweenShots = Mathf.Clamp(timeBetweenShots, minimumFireRate, float.MaxValue);
        }

        private void BulletInstantiating()
        {
            Bullet bullet = _bulletProvider.GetBullet();

            bullet.transform.position = shootPoint.position;
            bullet.transform.rotation = shootPoint.rotation;

            bullet.Initialize(_poolReturn, bulletDirection);
        }
    }
}

