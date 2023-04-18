using PFS.GamePlay.Enemy.patroller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PFS.GamePlay.Enemy
{
    public class GroundChecker : MonoBehaviour
    {
        private Patroller _patroller;

        private void Start()
        {
            _patroller = GetComponentInParent<Patroller>();
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
