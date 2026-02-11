using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpaceShooter.Viewport
{
    public interface ICheckBoundaries
    {
        public Vector2 CheckBoundaries(Vector2 position) { return position; }
    }
}
