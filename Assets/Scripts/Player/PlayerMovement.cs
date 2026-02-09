using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpaceShooter.PlayerInput;
using System;

namespace SpaceShooter.PlayerMove
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;

        private IInputProvider _input;

        public void Construct(IInputProvider input)
        {
            _input = input;
        }

        private void Update()
        {
            if (_input == null) return;

            HandleMovement();
        }

        private void HandleMovement()
        {
            Vector3 moveVector = new Vector3(_input.Horizontal, _input.Vertical, 0);
            transform.position += moveVector * speed * Time.deltaTime;
        }
    }
}

