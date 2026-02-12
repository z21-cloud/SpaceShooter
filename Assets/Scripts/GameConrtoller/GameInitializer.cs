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

namespace SpaceShooter.GameConrtoller
{
    public class GameInitializer : MonoBehaviour
    {
        // player
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private ViewportBoundaries _viewPort;

        // enemy
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private Path _path;
        [SerializeField] private EnemyPool _enemyPool;

        private void Awake()
        {
            _playerMovement.Construct(
                _inputManager, 
                _viewPort
            );

            _enemySpawner.Construct(
                _enemyPool,
                _path,
                _path
            );

            // test
            _enemySpawner.SpawnEnemy();
        }
    }
}

