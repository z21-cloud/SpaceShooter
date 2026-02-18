using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpaceShooter.Effects
{
    public class EffectManager : MonoBehaviour, IEffectService
    {
        [SerializeField] private EffectPool pool;
        [SerializeField] private float lifeTime = 1f;

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

