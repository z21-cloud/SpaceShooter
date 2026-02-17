using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpaceShooter.Health
{
    public class PlayerDeathHandler : MonoBehaviour, IDeath
    {
        public void Death()
        {
            Debug.Log($"Player Death Handler: {gameObject.name}");
            Destroy(gameObject);

            //effects & UI 
            // based on events. Destroy for testing
        }
    }
}

