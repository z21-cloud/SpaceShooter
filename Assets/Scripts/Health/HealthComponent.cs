using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using SpaceShooter.Score;

namespace SpaceShooter.Health
{
    public class HealthComponent : MonoBehaviour, IHealthProvider, IDamageable, IHealable
    {
        [Header("Health set-up")]
        [SerializeField] private float maxHealth = 100f;
        [SerializeField] private float startHealth = 100f;
        
        public float CurrentHealth { get; private set; }

        private const float DEATH_THRESHOLD = 0f;
        private List<IDamageListener> damageListener = new List<IDamageListener>();
        
        private void OnEnable()
        {
            ResetHealth();
        }

        public void AddListener(IDamageListener listener)
        {
            damageListener.Add(listener);
        }

        public void TakeDamage(float damage)
        {
            Debug.Log($"Health Component: Damage recieved {gameObject.name}; Current health: {CurrentHealth}");
            CurrentHealth -= damage;
            CurrentHealth = Mathf.Max(CurrentHealth, DEATH_THRESHOLD);

            foreach (var listener in damageListener) listener.OnDamageTaken();

            if (CurrentHealth <= DEATH_THRESHOLD)
            {
                if (gameObject.TryGetComponent<IDeath>(out var deathable))
                {
                    Debug.Log($"Health Component: Death provided {gameObject.name}");
                    deathable.Death();
                    ResetHealth();
                }
            }
        }

        private void ResetHealth()
        {
            CurrentHealth = startHealth;
        }

        public void Heal(float amount)
        {
            Debug.Log($"Health Component: Heal recieved {gameObject.name}; Current health: {CurrentHealth}");

            CurrentHealth += amount;
            CurrentHealth = Mathf.Min(CurrentHealth, maxHealth);    
        }

        private void OnDisable()
        {
            ResetHealth();
        }
    }
}

