using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SpaceShooter.GameConrtoller;

namespace SpaceShooter.Audio
{
    public class AudioManager : MonoBehaviour, IShootingAudioProvider, IDeathAudioProvider, IDamageAudioProvider
    {
        [Header("Shooting SFX")]
        [SerializeField] private AudioClip shootingClip;
        [SerializeField][Range(0, 1)] private float shootingVolume;

        [Header("Damage SFX")]
        [SerializeField] private AudioClip damageClip;
        [SerializeField][Range(0, 1)] private float damageVolume;

        [Header("Death SFX")]
        [SerializeField] private AudioClip deathClip;
        [SerializeField][Range(0, 1)] private float deathVolume;

        private void Awake()
        {
            ServiceLocator.Register<IShootingAudioProvider>(this);
            ServiceLocator.Register<IDeathAudioProvider>(this);
            ServiceLocator.Register<IDamageAudioProvider>(this);
        }

        public void PlayShootingSFX()
        {
            if (shootingClip == null)
            {
                Debug.LogError($"AudioManager: shooting clip is null!");
                return;
            }

            PlayAudioClip(shootingClip, shootingVolume);
        }

        public void PlayDamageSFX()
        {
            if (damageClip == null)
            {
                Debug.LogError($"AudioManager: damage clip is null!");
                return;
            }

            PlayAudioClip(damageClip, damageVolume);
        }

        public void PlayDeathSFX()
        {
            if(deathClip == null)
            {
                Debug.LogError($"AudioManager: death clip is null!");
                return;
            }

            PlayAudioClip(deathClip, deathVolume);
        }

        private void PlayAudioClip(AudioClip clip, float volume)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
        }
    }
}

