using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpaceShooter.Effects;
using SpaceShooter.Pooling;

public class EffectPool : MonoBehaviour, IPoolReturn
{
    [SerializeField] private Effect effect;
    [SerializeField] private int effectsCount = 20;
    [SerializeField] private Transform effectsSpawnParent;

    private ObjectPooling<Effect> pool;

    private void Awake()
    {
        pool = new ObjectPooling<Effect>(
                effect,
                effectsCount,
                effectsSpawnParent
            );
    }

    public Effect GetEffect() => pool.Get();

    public void ReturnToPool(GameObject effect) => pool.Release(effect.GetComponent<Effect>());
}
