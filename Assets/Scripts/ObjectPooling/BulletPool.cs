using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpaceShooter.Pooling
{
    public class BulletPool : MonoBehaviour
    {
        [Header("Bullet pool set-up")]
        //[SerializeField] private Bullet bullet;
        [SerializeField] private int bulletPoolSize = 10;
        [SerializeField] private Transform bulletTransformParent;

        // private variables
        // private ObjectPooling<Bullet> pool; // object pooling

        private void Awake()
        {
            // constructor
            // pool = 
        }

        // public Bullet Get() => pool.Get();
        // public void Release(Bullet bullet) => pool.Relesase(bullet);
    }
}

