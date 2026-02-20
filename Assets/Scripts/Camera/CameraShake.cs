using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpaceShooter.Health;

namespace SpaceShooter.Viewport
{
    public class CameraShake : MonoBehaviour, IDamageListener
    {
        [Header("Camera shake set-up")]
        [SerializeField] private float shakeDuration = 0.5f;
        [SerializeField] private float shakeMagnitude = 0.5f;

        private Vector3 initialPosition;

        private void Start()
        {
            initialPosition = transform.position;
        }

        public void OnDamageTaken()
        {
            Debug.Log($"Shake effect");
            StartCoroutine(CameraShakeCoroutine());
        }

        private IEnumerator CameraShakeCoroutine()
        {
            float timer = 0;
            while(timer <= shakeDuration)
            {
                transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
                timer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            transform.position = initialPosition;
        }
    }
}

