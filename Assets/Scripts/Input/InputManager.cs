using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace SpaceShooter.PlayerInput
{
    public class InputManager : MonoBehaviour
    {
        // properties
        public float Vertical { get; private set; }
        public float Horizontal { get; private set; }
        public bool MouseButton { get; private set; }

        // variables
        private int lMB = 0; // leftMouseButton 

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
            MouseButton = Input.GetMouseButtonDown(lMB);
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

