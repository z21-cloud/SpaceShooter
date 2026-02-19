using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpaceShooter.PlayerInput;
using System;
using SpaceShooter.Pooling;
using SpaceShooter.Effects;
using SpaceShooter.Audio;

namespace SpaceShooter.Shooting
{
    public class PlayerShooting : MonoBehaviour
    {
        [Header("shooting set-up")]
        [SerializeField] private float timeBetweenShots = 1f;
        [SerializeField] private Transform shootPoint;
        [SerializeField] private Vector2 bulletDirection = Vector2.up;

        private float currentTimer = 0f;

        private IInputProvider _input;
        private IBulletProvider _bulletProvider;
        private IPoolReturn _poolReturn; // bullet pool to return
        private IAudioProvider _audioProvider;

        public void Construct(IInputProvider input, 
            IBulletProvider bulletProvider, 
            IPoolReturn poolReturn,
            IAudioProvider audioProvider)
        {
            _input = input;
            _bulletProvider = bulletProvider;
            _poolReturn = poolReturn;
            _audioProvider = audioProvider;
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
            
            _audioProvider.PlayShootingSFX();
        }
    }
}
