using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpaceShooter.GameConrtoller;

namespace SpaceShooter.Effects
{
    public class EffectManager : MonoBehaviour, IEffectService
    {
        [Header("Effect manager set-up")]
        [SerializeField] private EffectPool pool;
        [SerializeField] private float lifeTime = 1f;

        private void Awake()
        {
            ServiceLocator.Register<IEffectService>(this);
        }

        public void PlayHitEffect(Vector2 position)
        {
            Effect effect = pool.GetEffect();

            effect.transform.position = position;
            var particleSystem = effect.gameObject.GetComponent<ParticleSystem>();
            particleSystem.Play();

            StartCoroutine(ReturnToPool());
        }

        private IEnumerator ReturnToPool()
        {
            yield return new WaitForSeconds(lifeTime);
            pool.ReturnToPool(this.gameObject);
        }
    }
}

