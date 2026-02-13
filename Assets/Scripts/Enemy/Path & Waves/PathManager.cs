using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpaceShooter.EnemyPath;

namespace SpaceShooter.PathManagement
{
    public class PathManager : MonoBehaviour
    {
        [Header("All available paths")]
        [SerializeField] private List<Path> allPaths = new List<Path>();

        public Path GetPath(int index)
        {
            if(index >= 0 && index < allPaths.Count)
            {
                return allPaths[index];
            }

            Debug.LogError($"Path with index {index} not found!");
            return allPaths[0];
        }

        public int PathCount => allPaths.Count;
    }
}

