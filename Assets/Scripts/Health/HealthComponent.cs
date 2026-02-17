using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpaceShooter.Health
{
    public class HealthComponent : MonoBehaviour, IHealthProvider, IDamageable, IHealable
    {
        [Header("Health set-up")]
        [SerializeField] private float startHealth = 100f;
        public float CurrentHealth { get; private set; }

        private const float DEATH_THRESHOLD = 0f;

        private void Start()
        {
            CurrentHealth = startHealth;
        }

        public void TakeDamage(float damage)
        {
            Debug.Log($"Health Component: Damage recieved {gameObject.name}; Current health: {CurrentHealth}");
            CurrentHealth -= damage;
            CurrentHealth = Mathf.Max(CurrentHealth, DEATH_THRESHOLD);

            if(CurrentHealth <= DEATH_THRESHOLD)
            {
                if (gameObject.TryGetComponent<IDeath>(out var deathable))
                {
                    Debug.Log($"Health Component: Death provided {gameObject.name}");
                    deathable.Death();
                }
            }
        }
    }
}

