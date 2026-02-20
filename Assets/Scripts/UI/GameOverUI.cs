using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpaceShooter.Score;
using TMPro;

namespace SpaceShooter.UI
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private ScoreDataSO scoreData;
        [SerializeField] private TextMeshProUGUI scoreText;
        void Start()
        {
            scoreText.text = $"FINAL SCORE: {scoreData.LastSessionScore.ToString()}";
        }
    }
}

