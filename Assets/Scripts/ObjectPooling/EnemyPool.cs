using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpaceShooter.Pooling
{
    public class EnemyPool : MonoBehaviour
    {
        [Header("Enemy pool set-up")]
        //[SerializeField] private Enemy enemy;
        [SerializeField] private int enemyPoolSize = 10;
        [SerializeField] private Transform enemyTransformParent;

        // private variables
        // private ObjectPooling<Enemy> pool; // object pooling

        private void Awake()
        {
            // constructor
            // pool = 
        }

        // public Enemy Get() => pool.Get();
        // public void Release(Enemy enemy) => pool.Relesase(enemy);
    }
}

