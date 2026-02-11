using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpaceShooter.PlayerInput;
using System;
using SpaceShooter.Viewport;

namespace SpaceShooter.PlayerMove
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;

        private IInputProvider _input;
        private ICheckBoundaries _boundaries;

        public void Construct(IInputProvider input, ICheckBoundaries boundaries)
        {
            _input = input;
            _boundaries = boundaries;
        }

        private void Update()
        {
            if (_input == null) return;

            HandleMovement();
        }

        private void HandleMovement()
        {
            Vector3 moveVector = new Vector3(_input.Horizontal, _input.Vertical, 0);
            Vector3 nextPosition = transform.position + moveVector * speed * Time.deltaTime;
        
            if(_boundaries != null)
            {
                nextPosition = _boundaries.CheckBoundaries(nextPosition);
            }

            transform.position = nextPosition;
        }
    }
}

