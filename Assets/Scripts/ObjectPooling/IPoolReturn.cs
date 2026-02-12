using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpaceShooter.Pooling
{
    public interface IPoolReturn
    {
        public void ReturnToPool(GameObject gameObject);
    }
}

