using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpaceShooter.Health;

namespace SpaceShooter.Shooting
{
    public class BulletDamageable : MonoBehaviour, IDamageable
    {
        public void TakeDamage(float damage)
        {
            Debug.Log($"BulletDamageable: {gameObject.name} returned to pool");
        }
    }
}
