using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpaceShooter.PlayerInput;
using SpaceShooter.PlayerMove;
using SpaceShooter.Viewport;
using SpaceShooter.Enemies;
using SpaceShooter.EnemiesSpawner;
using SpaceShooter.EnemyPath;
using SpaceShooter.Pooling;
using SpaceShooter.PathManagement;
using SpaceShooter.WaveManagement;
using SpaceShooter.Shooting;

namespace SpaceShooter.GameConrtoller
{
    public class GameInitializer : MonoBehaviour
    {
        // player
        [Header("Player set-up || Movement")]
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private ViewportBoundaries _viewPort;

        [Header("Player set-up || Shooting")]
        [SerializeField] private BulletPool _playerBulletPool;
        [SerializeField] private PlayerShooting _playerShooting;

        // enemy
        [Header("Enemy set-up")]
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private PathManager _pathManager;
        [SerializeField] private WaveController _waveConrtoller;
        [SerializeField] private BulletPool _enemyBulletPool;

        private void Awake()
        {
            _playerMovement.Construct(
                _inputManager, 
                _viewPort
            );

            _playerShooting.Construct(
                _inputManager,
                _playerBulletPool,
                _playerBulletPool
            );

            _enemySpawner.Construct(
                _enemyPool,
                _pathManager,
                _enemyBulletPool
            );

            _waveConrtoller.Construct(
                _enemySpawner
            );
        }

        private void Start()
        {
            _waveConrtoller.StartWaves();
        }
    }
}

