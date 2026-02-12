using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using SpaceShooter.EnemyPath;

namespace SpaceShooter.Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;

        private IPath currentPath;
        private int currentWaypointIndex = 0;
        private const float DISTANCE_THRESHOLD = 0.1f;

        public void Construct(IPath path)
        {
            currentPath = path;
        }

        private void Update()
        {
            if (currentPath == null || currentWaypointIndex >= currentPath.PointsCount) return;

            HandleMovement();
        }

        private void HandleMovement()
        {
            Vector2 targetPosition = currentPath.GetWaypoint(currentWaypointIndex);

            transform.position = Vector2.MoveTowards(
                    transform.position,
                    targetPosition,
                    speed * Time.deltaTime
                );

            if (Vector2.Distance(transform.position, targetPosition) < DISTANCE_THRESHOLD)
                currentWaypointIndex++;
        }
    }
}

