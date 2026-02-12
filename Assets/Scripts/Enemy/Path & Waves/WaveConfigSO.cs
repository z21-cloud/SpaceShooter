using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "New WaveConfig")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] private Transform pathPrefab;
    [SerializeField] private float enemyWaveMoveSpeed = 5f;

    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public float GetEnemyMoveSpeed()
    {
        return enemyWaveMoveSpeed;
    }

    public List<Transform> GetWaypoings()
    {
        List<Transform> waypoints = new List<Transform>(pathPrefab.childCount);

        for (int i = 0; i < pathPrefab.childCount; i++)
        {
            waypoints.Add(pathPrefab.GetChild(i));
        }

        return waypoints;
    }
}
