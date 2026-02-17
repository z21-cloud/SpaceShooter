using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpaceShooter.Health
{
    public interface IHealthProvider
    {
        public float CurrentHealth { get; }
    }
}

