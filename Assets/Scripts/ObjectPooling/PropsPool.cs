using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpaceShooter.Pooling
{
    public class PropsPool : MonoBehaviour
    {
        [Header("Props pool set-up")]
        //[SerializeField] private Props props;
        [SerializeField] private int _propsPoolSize = 10;
        [SerializeField] private Transform _propsTransformParent;

        // private variables
        // private ObjectPooling<Props> pool; // object pooling

        private void Awake()
        {
            // constructor
            // pool = 
        }

        // public Props Get() => pool.Get();
        // public void Release(Props props) => pool.Relesase(props);
    }
}

