using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpaceShooter.EnemyPath
{
    public class Path : MonoBehaviour, IPath
    {
        // config for set-up
        [SerializeField] private WaveConfigSO waveConfig;
        
        // cache 
        private List<Transform> waypoints;
        
        // counts for check if in bounds
        public int PointsCount => waypoints.Count;

        private void Awake()
        {
            // cache
            waypoints = waveConfig.GetWaypoints(); 
        }

        public Vector2 GetWaypoint(int index)
        {
            if (index >= 0 && index < waypoints.Count) return waypoints[index].position;

            return Vector2.zero;
        }
    }
}

