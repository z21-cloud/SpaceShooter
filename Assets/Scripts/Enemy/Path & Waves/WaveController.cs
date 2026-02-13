using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpaceShooter.EnemiesWaveConfig;
using SpaceShooter.EnemiesSpawner;

namespace SpaceShooter.WaveManagement
{
    public class WaveController : MonoBehaviour
    {
        [Header("Wave config")]
        [SerializeField] private List<WaveConfigSO> waveConfig;
        [SerializeField] private float delayBetweenEnemySpawns = 1f;
        [SerializeField] private float delayBetweenWaves = 3f;

        private EnemySpawner enemySpawner;
        private int currentWaveIndex = 0;
        private bool isSpawning = false;
        private List<Transform> waypoints;

        // counts for check if in bounds
        public int PointsCount => waypoints.Count;

        public void Construct(EnemySpawner spawner)
        {
            enemySpawner = spawner;
        }

        public void StartWaves()
        {
            if(!isSpawning)
            {
                StartCoroutine(SpawnAllWavesCoroutine());
            }
        }

        public void StartWave(int waveIndex)
        {
            if(waveIndex >= 0 && waveIndex < waveConfig.Count)
            {
                StartCoroutine(SpawnSingleWaveCoroutine(waveIndex));
            }
        }

        private IEnumerator SpawnAllWavesCoroutine()
        {
            isSpawning = true;

            for (int i = 0; i < waveConfig.Count; i++)
            {
                currentWaveIndex = i;
                yield return StartCoroutine(SpawnSingleWaveCoroutine(currentWaveIndex));

                if(i < waveConfig.Count - 1)
                {
                    yield return new WaitForSeconds(delayBetweenWaves);
                }
            }

            isSpawning = false;
            Debug.Log($"WaveConrtoller: all waves spawned");
        }

        private IEnumerator SpawnSingleWaveCoroutine(int waveIndex)
        {
            WaveConfigSO currentWave = waveConfig[waveIndex];
            int enemiesCount = currentWave.GetEnemiesCountPerWave();

            Debug.Log($"WaveConrtoller: Wave {waveIndex + 1}, spawns {enemiesCount} enemies");

            for (int i = 0; i < enemiesCount; i++)
            {
                enemySpawner.SpawnEnemy(waveIndex);

                if (i < enemiesCount - 1)
                {
                    yield return new WaitForSeconds(delayBetweenEnemySpawns);
                }
            }
        }

        public int GetCurrentWaveIndex() => currentWaveIndex;

        public int GetTotalWaves() => waveConfig.Count;
    }

}
