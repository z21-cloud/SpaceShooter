using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpaceShooter.PlayerInput;
using SpaceShooter.PlayerMove;
using SpaceShooter.Viewport;
using SpaceShooter.Enemies;
using SpaceShooter.EnemyPath;

namespace SpaceShooter.GameConrtoller
{
    public class GameInitializer : MonoBehaviour
    {
        // player
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private ViewportBoundaries _viewPort;

        // enemy
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private Path _path;

        private void Awake()
        {
            _playerMovement.Construct(
                _inputManager, 
                _viewPort
                );

            _enemyMovement.Construct(
                _path
                );
        }
    }
}

