using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter.EnemiesWaveConfig
{
    [CreateAssetMenu(fileName = "WaveConfig", menuName = "New WaveConfig")]
    public class WaveConfigSO : ScriptableObject
    {
        [Header("Enemy set-up")]
        [SerializeField] private int enemyCount = 5;

        [Header("Path settings")]
        [SerializeField] private List<GameObject> enemyPrefabs;
        [SerializeField] private Transform pathPrefab;
        [SerializeField] private float enemyWaveMoveSpeed = 5f;

        private List<Transform> _waypoints;

        private List<Transform> Waypoints
        {
            get
            {
                if (_waypoints == null || _waypoints.Count == 0) Construct();
                return _waypoints;
            }
        }

        private void Construct()
        {
            Debug.Log($"Wave Config: Construcred");
            _waypoints = new List<Transform>(pathPrefab.childCount);

            for (int i = 0; i < pathPrefab.childCount; i++)
            {
                _waypoints.Add(pathPrefab.GetChild(i));
            }
        }

        public List<Transform> GetWaypoints() => Waypoints.Count > 0 ? Waypoints : null;
        public float GetEnemyMoveSpeed() => enemyWaveMoveSpeed;
        public int GetEnemiesCountPerWave() => enemyCount;


       /* 
        public Transform GetCurrentWaypoint(int index)
        {
            return (index >= 0 && index < Waypoints.Count) ? Waypoints[index] : null;
        }


        public int GetEnemyCount() => enemyPrefabs.Count;
        public GameObject GetEnemyPrefab(int index) => enemyPrefabs[index];
       */
    }
}

