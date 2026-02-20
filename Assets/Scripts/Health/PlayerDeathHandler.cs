using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpaceShooter.GameConrtoller;
using SpaceShooter.Score;
using System;

namespace SpaceShooter.Health
{
    public class PlayerDeathHandler : MonoBehaviour, IDeath
    {
        public static event Action OnDeathAction;
        public void Death()
        {
            Debug.Log($"Player Death Handler: {gameObject.name}");

            ServiceLocator.Get<IScoreReset>().ResetScore();

            OnDeathAction?.Invoke();

            // effects & UI 
            // based on events. Destroy for testing
            Destroy(gameObject);
        }
    }
}

