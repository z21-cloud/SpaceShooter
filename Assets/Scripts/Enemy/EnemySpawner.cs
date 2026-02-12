using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpaceShooter.Pooling;
using SpaceShooter.EnemyPath;
using SpaceShooter.Enemies;

namespace SpaceShooter.EnemiesSpawner
{
    public class EnemySpawner : MonoBehaviour
    {
        private IPath path;
        private EnemyPool pool;
        public void Construct(EnemyPool enemyPool, IPath currentPath)
        {
            pool = enemyPool;
            path = currentPath;
        }

        public void SpawnEnemy()
        {
            Enemy enemy = pool.Get();

            EnemyMovement movement = enemy.gameObject.GetComponent<EnemyMovement>();

            movement.Construct(path, pool);

            enemy.gameObject.transform.position = path.GetWaypoint(0);
        }
    }
}

