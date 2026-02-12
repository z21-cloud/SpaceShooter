using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpaceShooter.Pooling
{
    public class EnemyPool : MonoBehaviour, IPoolReturn
    {
        [Header("Enemy pool set-up")]
        [SerializeField] private Enemy enemy;
        [SerializeField] private int _enemyPoolSize = 10;
        [SerializeField] private Transform _enemyTransformParent;

        // private variables
        private ObjectPooling<Enemy> pool; // object pooling

        private void Awake()
        {
            // constructor
            pool = new ObjectPooling<Enemy>(
                enemy,
                _enemyPoolSize,
                _enemyTransformParent
            );
        }

        public void ReturnToPool(GameObject enemy) => pool.Release(enemy.GetComponent<Enemy>());

        public Enemy Get() => pool.Get();
    }
}

