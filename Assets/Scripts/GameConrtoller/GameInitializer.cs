using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpaceShooter.PlayerInput;
using SpaceShooter.PlayerMove;

namespace SpaceShooter.GameConrtoller
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private PlayerMovement _playerMovement;

        private void Awake()
        {
            _playerMovement.Construct(_inputManager);
        }
    }
}

