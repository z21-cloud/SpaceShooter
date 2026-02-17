using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpaceShooter.Health
{
    public class DeathComponent : MonoBehaviour, IDeath
    {
        public void Death()
        {
            Debug.Log($"Death Component: Death {gameObject.name}");
            Destroy(gameObject);
        }
    }
}

