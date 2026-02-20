using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using SpaceShooter.Health;
using SpaceShooter.Score;

namespace SpaceShooter.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Slider healthBar;
        [SerializeField] private TextMeshProUGUI scoreText;

        private IHealthProvider uiHealth;
        private IScoreProvider uiScore;

        public void Construct(IHealthProvider healthProvider, IScoreProvider scoreProvider)
        {
            uiHealth = healthProvider;
            uiScore = scoreProvider;
        }

        private void Start()
        {
            healthBar.maxValue = uiHealth.CurrentHealth;
        }

        private void Update()
        {
            UpdateHealth();
            UpdateScore();
        }

        private void UpdateHealth()
        {
            healthBar.value = uiHealth.CurrentHealth;
        }

        private void UpdateScore()
        {
            scoreText.text = uiScore.CurrentScore.ToString("00000000");
        }
    }
}

