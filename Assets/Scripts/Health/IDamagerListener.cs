using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpaceShooter.Health
{
    public interface IDamagerListener
    {
        public void OnDamageTaken(float damage);
    }
}

