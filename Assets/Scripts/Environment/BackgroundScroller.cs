using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpaceShooter.Environment
{
    public class BackgroundScroller : MonoBehaviour
    {
        [SerializeField] private Vector2 moveSpeed = new Vector2 (2f, 2f);

        private Vector2 offset;
        private Material material;

        private void Start()
        {
            if (gameObject.TryGetComponent<SpriteRenderer>(out var spriteRenderer))
            {
                material = spriteRenderer.material;
            }
            else
            {
                Debug.LogError($"BackgroundController: {gameObject.name} material is null");
            }
        }

        private void Update()
        {
            if (material == null) return;

            offset += moveSpeed * Time.deltaTime;
            material.mainTextureOffset = offset;
        }
    }
}

