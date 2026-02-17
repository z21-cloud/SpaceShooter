using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpaceShooter.Pooling;
using SpaceShooter.EnemyPath;
using SpaceShooter.Enemies;
using SpaceShooter.PathManagement;
using SpaceShooter.Health;

namespace SpaceShooter.EnemiesSpawner
{
    public class EnemySpawner : MonoBehaviour
    {
        private EnemyPool pool;
        private PathManager pathManager;

        public void Construct(EnemyPool enemyPool, PathManager paths)
        {
            pool = enemyPool;
            pathManager = paths;
        }

        public void SpawnEnemy(int pathIndex)
        {
            Path currentPath = pathManager.GetPath(pathIndex);
            SpawnEnemyOnPath(currentPath);
        }

        private void SpawnEnemyOnPath(Path currentPath)
        {
            if (currentPath == null) return;

            Enemy enemy = pool.Get();

            if(enemy.TryGetComponent<EnemyMovement>(out var movement))
            {
                movement.Construct(currentPath, currentPath, pool);
                enemy.transform.position = currentPath.GetWaypoint(0);
            }

            if(enemy.TryGetComponent<EnemyDeathHandler>(out var deathHandler))
            {
                deathHandler.Initialize(pool);
            }
        }
    }
}

