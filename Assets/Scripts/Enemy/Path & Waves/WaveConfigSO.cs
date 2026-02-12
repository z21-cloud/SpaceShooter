using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "New WaveConfig")]
public class WaveConfigSO : ScriptableObject
{
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
        _waypoints = new List<Transform>(pathPrefab.childCount);

        for (int i = 0; i < pathPrefab.childCount; i++)
        {
            _waypoints.Add(pathPrefab.GetChild(i));
        }
    }

    public Transform GetStartingWaypoint() => Waypoints.Count > 0 ? Waypoints[0] : null;

    public Transform GetCurrentWaypoint(int index)
    {
        return (index >= 0 && index < Waypoints.Count) ? Waypoints[index] : null;
    }
    public List<Transform> GetWaypoints() => Waypoints.Count > 0 ? Waypoints : null;

    public int GetWaypointsCount() => Waypoints.Count;
    public float GetEnemyMoveSpeed() => enemyWaveMoveSpeed;
}
