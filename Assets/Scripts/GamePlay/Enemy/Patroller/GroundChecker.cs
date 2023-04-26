using PFS.GamePlay.Enemy.dynamicEnemy;
using UnityEngine;

namespace PFS.GamePlay.Enemy
{
    public class GroundChecker : MonoBehaviour
    {
        private DynamicEnemy _patroller;

        private void Start()
        {
            _patroller = GetComponentInParent<DynamicEnemy>();
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Tilemap") == true)
            {
                Debug.Log("Is not Ground!");
                _patroller.SwapSpriteX();
            }
        }
    }
}
