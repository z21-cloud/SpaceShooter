using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpaceShooter.Effects
{
    public interface IEffectService
    {
        public void PlayHitEffect(Vector2 positoin);
    }
}

