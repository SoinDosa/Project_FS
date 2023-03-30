using PFS.GamePlay.Player.playerController;
using PFS.UI.Common.popupBase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PFS.GamePlay.Rule.gameOverChecker
{
    public class GameOverChecker : MonoBehaviour
    {
        public static bool isGameOver = false;

        [SerializeField] private PopupBase _gameOverPopup;
        private PlayerController _playerController;
        private bool isGameOverPopupOpen = false;

        private void Awake()
        {
            _playerController = FindObjectOfType<PlayerController>();
        }
    }
}

