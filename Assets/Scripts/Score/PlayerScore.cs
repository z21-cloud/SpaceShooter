using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpaceShooter.GameConrtoller;

namespace SpaceShooter.Score
{
    public class PlayerScore : MonoBehaviour, IScoreProvider, IScoreEncrease, IScoreDecrease, IScoreReset
    {
        [SerializeField] private int currentScore = 0;

        public int CurrentScore { get; private set; }

        private const int SCORE_THRESHOLD = 0;

        private void Awake()
        {
            ServiceLocator.Register<IScoreEncrease>(this);
            ServiceLocator.Register<IScoreReset>(this);
            CurrentScore = currentScore;
        }

        public void EncreaseScore(int value)
        {
            CurrentScore += value;
            CurrentScore = Mathf.Clamp(CurrentScore, SCORE_THRESHOLD, int.MaxValue);
            Debug.Log($"PlayerScore: Current Score: {CurrentScore}");
        }

        public void DecreaseScore(int value)
        {
            CurrentScore -= value;
            CurrentScore = Mathf.Clamp(CurrentScore, SCORE_THRESHOLD, int.MaxValue);
            Debug.Log($"PlayerScore: Current Score: {CurrentScore}");
        }

        public void ResetScore()
        {
            CurrentScore = 0;
            Debug.Log($"PlayerScore: Current Score: {CurrentScore}");
        }
    }
}

