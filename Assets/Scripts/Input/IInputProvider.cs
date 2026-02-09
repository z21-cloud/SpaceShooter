using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpaceShooter.PlayerInput
{
    public interface IInputProvider
    {
        float Horizontal { get; }
        float Vertical { get; }
        bool MouseButton { get; }
    }
}

