using PFS.GamePlay.Enemy.dynamicEnemy;
using UnityEngine;

namespace PFS.GamePlay.Enemy
{
    public class WallChecker : MonoBehaviour
    {
        private DynamicEnemy _patroller;

        private void Awake()
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
