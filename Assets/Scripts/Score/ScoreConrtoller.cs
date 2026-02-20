using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpaceShooter.Health;

namespace SpaceShooter.Score
{
    public class ScoreConrtoller : MonoBehaviour, IDamageListener
    {
        [SerializeField] private ScoreManager playerScore;
        [SerializeField] private int decraseScoreAmount = 10;

        public void OnDamageTaken()
        {
            playerScore.DecreaseScore(decraseScoreAmount);
        }
    }
}

