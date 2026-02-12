using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using SpaceShooter.EnemyPath;
using SpaceShooter.Pooling;

namespace SpaceShooter.Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        private IPath currentPath;
        private IPoolReturn pool;
        private IMoveable getSpeed;
        private int currentWaypointIndex = 0;
        private const float DISTANCE_THRESHOLD = 0.1f;
        private float speed = 5f;

        public void Construct(IPath path, IMoveable moveable, IPoolReturn poolReturn)
        {
            currentPath = path;
            getSpeed = moveable;
            pool = poolReturn;
            currentWaypointIndex = 0;
        }

        private void Update()
        {
            if (currentPath == null || currentWaypointIndex >= currentPath.PointsCount)
            {
                pool?.ReturnToPool(this.gameObject);
                return;
            }

            HandleMovement();
        }

        private void HandleMovement()
        {
            Vector2 targetPosition = currentPath.GetWaypoint(currentWaypointIndex);

            speed = getSpeed.GetWaveSpeed();

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

