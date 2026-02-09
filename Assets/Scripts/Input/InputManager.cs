using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace SpaceShooter.PlayerInput
{
    public class InputManager : MonoBehaviour, IInputProvider
    {
        // properties
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }
        public bool MouseButton { get; private set; }

        // variables
        private int _lMB = 0; // leftMouseButton 

        // unity default method
        private void Update()
        {
            HorizontalInput();
            VerticalInput();
            MouseInput();
        }

        // custom methods
        private void MouseInput()
        {
            MouseButton = Input.GetMouseButtonDown(_lMB);
        }

        private void VerticalInput()
        {
            Vertical = Input.GetAxisRaw("Vertical");
        }

        private void HorizontalInput()
        {
            Horizontal = Input.GetAxisRaw("Horizontal");
        }
    }
}

