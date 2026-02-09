using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpaceShooter.Enemies
{
    public interface IDamageable     
    {
        public void TakeDamage(float damage) { }
    }
}

