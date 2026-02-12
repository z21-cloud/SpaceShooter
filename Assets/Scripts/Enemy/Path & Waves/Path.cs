using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpaceShooter.Enemies;

namespace SpaceShooter.EnemyPath
{
    public class Path : MonoBehaviour, IPath, IMoveable
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
            Debug.Log($"Path: Constructed");
        }

        public Vector2 GetWaypoint(int index)
        {
            if (index >= 0 && index < waypoints.Count) return waypoints[index].position;

            return Vector2.zero;
        }

        public float GetWaveSpeed() => waveConfig.GetEnemyMoveSpeed();

        public Vector2 GetStartWaypoint() => waypoints[0].position;
    }
}

