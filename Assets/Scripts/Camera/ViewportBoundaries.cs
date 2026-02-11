using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpaceShooter.Viewport
{
    public class ViewportBoundaries : MonoBehaviour, ICheckBoundaries
    {
        private const float LEFT_BOUND_PADDING = 1f;
        private const float RIGHT_BOUND_PADDING = 1f;
        private const float TOP_BOUND_PADDING = 7f;
        private const float BOTTOM_BOUND_PADDING = 1f;
        private Vector2 minBoundaries;
        private Vector2 maxBoundaries;

        private void Start()
        {
            ViewpornSetup();
        }

        private void ViewpornSetup()
        {
            Camera camera = Camera.main;
            minBoundaries = camera.ViewportToWorldPoint(new Vector2(0, 0)); // left down bottom
            maxBoundaries = camera.ViewportToWorldPoint(new Vector2(1, 1)); // right up bottom
        }

        public Vector2 CheckBoundaries(Vector2 position) 
        {
            position.x = Mathf.Clamp(position.x, minBoundaries.x + LEFT_BOUND_PADDING, maxBoundaries.x - RIGHT_BOUND_PADDING);
            position.y = Mathf.Clamp(position.y, minBoundaries.y + BOTTOM_BOUND_PADDING, maxBoundaries.y - TOP_BOUND_PADDING);
            return position;
        }
    }
}

