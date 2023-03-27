using PFS.GamePlay.Player.playerController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PFS.GamePlay.Rule.gameOverChecker
{
    public class GameOverChecker : MonoBehaviour
    {
        public static bool isGameOver = false;

        private PlayerController _playerController;

        private void Awake()
        {
            _playerController = FindObjectOfType<PlayerController>();
        }

        private void Update()
        {
            if (isGameOver == true)
            {
                Debug.Log("Game Over");
            }
        }
    }
}

