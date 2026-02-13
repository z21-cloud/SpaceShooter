using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpaceShooter.Shooting;

namespace SpaceShooter.Pooling
{
    public class BulletPool : MonoBehaviour, IBulletProvider, IPoolReturn
    {
        [Header("Bullet pool set-up")]
        [SerializeField] private Bullet bullet;
        [SerializeField] private int _bulletPoolSize = 10;
        [SerializeField] private Transform _bulletTransformParent;
        
        // private variables
        private ObjectPooling<Bullet> pool; // object pooling

        private void Awake()
        {
            // constructor
            pool = new ObjectPooling<Bullet>(
                    bullet,
                    _bulletPoolSize,
                    _bulletTransformParent
                );
        }

        public void ReturnToPool(GameObject bullet) => pool.Release(bullet.GetComponent<Bullet>());

        public Bullet GetBullet() => pool.Get();
    }
}

