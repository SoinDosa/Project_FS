using PFS.GamePlay.Enemy.dynamicEnemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PFS.GamePlay.Enemy
{
    public class WallChecker : MonoBehaviour
    {
        private DynamicEnemy _patroller;

        private void Start()
        {
            _patroller = GetComponentInParent<DynamicEnemy>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Tilemap") == true)
            {
                Debug.Log("Is Wall!");
                _patroller.SwapSpriteX();
            }
        }
    }
}
