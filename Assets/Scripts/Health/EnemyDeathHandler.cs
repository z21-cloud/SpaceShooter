using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpaceShooter.Pooling;
using System;

namespace SpaceShooter.Health
{
    public class EnemyDeathHandler : MonoBehaviour, IDeath
    {
        private IPoolReturn pool;

        public void Initialize(IPoolReturn pool)
        {
            this.pool = pool;
        }

        public void Death()
        {
            Debug.Log($"Death Component: Death {gameObject.name}");

            ReturnToPool();
        }

        private void ReturnToPool()
        {
            if(pool != null)
            {
                pool.ReturnToPool(this.gameObject);
            }
            else
            {
                Debug.LogError($"Enemy Death Handler: Pool referense is misiising on {gameObject.name}");
                Destroy(gameObject);
            }
        }
    }
}

