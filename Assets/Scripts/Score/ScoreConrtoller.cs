using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpaceShooter.Score
{
    public class ScoreConrtoller : MonoBehaviour, IScoreDamageListener
    {
        [SerializeField] private PlayerScore playerScore;
        [SerializeField] private int decraseScoreAmount = 10;
        public void OnScoreDamage()
        {
            playerScore.DecreaseScore(decraseScoreAmount);
        }
    }
}

