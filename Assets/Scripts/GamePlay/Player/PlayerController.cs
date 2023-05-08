using PFS.GamePlay.Player.playerEntity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using PFS.GamePlay.Rule.gameManager;
using PFS.UI.GameScene.gameScene;
using UnityEngine.Localization.Settings;

namespace PFS.GamePlay.Player.playerController
{
    public class PlayerController : MonoBehaviour
    {
        private GameScene _gameScene;
        public List<PlayerEntity> playerEntities;
        public Action<float> MoveEntities;
        public Action JumpEntities;

        private void Start()
        {
            _gameScene = FindObjectOfType<GameScene>();
        }

        private void Update()
        {
            if (playerEntities.Count == 0 && GameManager.isGameOver == false)
            {
                GameManager.isGameOver = true;
                _gameScene.OpenGameOverPopup(0);
            }
        }

        public void PlayerMove(float dir)
        {
            if(MoveEntities != null)
            {
                MoveEntities(dir);
            }
        }

        public void JumpPlayer()
        {
            if (JumpEntities != null)
            {
                JumpEntities();
            }
        }
    }
}
