using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpaceShooter.EnemyPath
{
    public interface IPath
    {
        public Vector2 GetWaypoint(int index);
        public int PointsCount { get; }
    }
}

