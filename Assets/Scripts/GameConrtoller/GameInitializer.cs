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

namespace SpaceShooter.GameConrtoller
{
    public class GameInitializer : MonoBehaviour
    {
        // player
        [Header("Player set-up")]
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private ViewportBoundaries _viewPort;

        // enemy
        [Header("Enemy set-up")]
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private PathManager _pathManager;

        private void Awake()
        {
            _playerMovement.Construct(
                _inputManager, 
                _viewPort
            );

            _enemySpawner.Construct(
                _enemyPool,
                _pathManager
            );

            // test
            _enemySpawner.SpawnEnemy(0);
            _enemySpawner.SpawnEnemy(1);
        }
    }
}

