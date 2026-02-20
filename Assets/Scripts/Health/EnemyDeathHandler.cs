using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpaceShooter.Pooling;
using SpaceShooter.Audio;
using SpaceShooter.GameConrtoller;
using SpaceShooter.Score;

namespace SpaceShooter.Health
{
    public class EnemyDeathHandler : MonoBehaviour, IDeath
    {
        [Header("Score Reward")]
        [SerializeField] private int scoreReward = 50;
        private IPoolReturn pool;

        public void Initialize(IPoolReturn pool)
        {
            this.pool = pool;
        }

        public void Death()
        {
            Debug.Log($"Death Component: Death {gameObject.name}");
            
            ServiceLocator.Get<IDeathAudioProvider>().PlayDeathSFX();
            ServiceLocator.Get<IScoreIncrease>().IncreaseScore(scoreReward);

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

