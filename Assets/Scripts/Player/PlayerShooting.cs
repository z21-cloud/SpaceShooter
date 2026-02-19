using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpaceShooter.PlayerInput;
using System;
using SpaceShooter.Pooling;
using SpaceShooter.Effects;

namespace SpaceShooter.Shooting
{
    public class PlayerShooting : MonoBehaviour
    {
        [Header("shooting set-up")]
        [SerializeField] private float timeBetweenShots = 1f;
        [SerializeField] private Transform shootPoint;
        [SerializeField] private Vector2 bulletDirection = Vector2.up;

        private float currentTimer = 0f;

        private IBulletProvider _bulletProvider;
        private IPoolReturn _poolReturn; // bullet pool to return
        private IInputProvider _input;

        public void Construct(IInputProvider input, 
            IBulletProvider bulletProvider, 
            IPoolReturn poolReturn)
        {
            _input = input;
            _bulletProvider = bulletProvider;
            _poolReturn = poolReturn;
        }

        private void Update()
        {
            if (_input == null) return;

            currentTimer += Time.deltaTime;
            if (_input.MouseButton && currentTimer >= timeBetweenShots)
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

            bullet.Initialize(_poolReturn, bulletDirection);
        }
    }
}
