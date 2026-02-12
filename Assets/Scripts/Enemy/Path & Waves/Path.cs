using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpaceShooter.EnemyPath
{
    public class Path : MonoBehaviour, IPath
    {
        [SerializeField] private List<Transform> path;

        public int PointsCount => path.Count;

        public Vector2 GetWaypoint(int index)
        {
            if (index >= 0 && index < path.Count) return path[index].position;

            return Vector2.zero;
        }
    }
}

