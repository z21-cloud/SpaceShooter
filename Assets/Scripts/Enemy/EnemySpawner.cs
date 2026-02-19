using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpaceShooter.Pooling;
using SpaceShooter.EnemyPath;
using SpaceShooter.Enemies;
using SpaceShooter.PathManagement;
using SpaceShooter.Health;
using SpaceShooter.Shooting;
using SpaceShooter.Effects;

namespace SpaceShooter.EnemiesSpawner
{
    public class EnemySpawner : MonoBehaviour
    {
        private EnemyPool enemyPool;
        private PathManager pathManager;
        private BulletPool bulletPool;

        public void Construct(EnemyPool enemyPool,
            PathManager pathManager, 
            BulletPool bulletPool)
        {
            this.enemyPool = enemyPool;
            this.pathManager = pathManager;
            this.bulletPool = bulletPool;
        }

        public void SpawnEnemy(int pathIndex)
        {
            Path currentPath = pathManager.GetPath(pathIndex);
            SpawnEnemyOnPath(currentPath);
        }

        private void SpawnEnemyOnPath(Path currentPath)
        {
            if (currentPath == null) return;

            Enemy enemy = enemyPool.Get();

            if(enemy.TryGetComponent<EnemyMovement>(out var movement))
            {
                movement.Construct(currentPath, currentPath, enemyPool);
                enemy.transform.position = currentPath.GetWaypoint(0);
            }

            if(enemy.TryGetComponent<EnemyDeathHandler>(out var deathHandler))
            {
                deathHandler.Initialize(enemyPool);
            }

            if(enemy.TryGetComponent<EnemyShooting>(out var enemyShooting))
            {
                enemyShooting.Construct(bulletPool, bulletPool);
            }
        }
    }
}

