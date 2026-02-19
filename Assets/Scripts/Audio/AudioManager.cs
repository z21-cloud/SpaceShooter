using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpaceShooter.Audio
{
    public class AudioManager : MonoBehaviour, IAudioProvider
    {
        [Header("Shooting SFX")]
        [SerializeField] private AudioClip shootingClip;
        [SerializeField][Range(0, 1)] private float shootingVolume;

        public void PlayShootingSFX()
        {
            if (shootingClip == null)
            {
                Debug.LogError($"AudioManager: shooting clip is null!");
                return;
            }

            AudioSource.PlayClipAtPoint(shootingClip, Camera.main.transform.position, shootingVolume);
        }
    }
}

