using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpaceShooter.Health
{
    public interface IHealable
    {
        public void Heal(float heal);
    }
}

