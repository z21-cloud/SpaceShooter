using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpaceShooter.Health
{
    public interface IDamageListener
    {
        public void OnDamageTaken();
    }
}

