using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpaceShooter.Shooting
{
    public interface IBulletProvider
    {
        public Bullet GetBullet();
    }
}

