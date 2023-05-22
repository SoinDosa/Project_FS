using PFS.GamePlay.Rule.gameManager;
using PFS.UI.Common.popupBase;
using System;
using TMPro;
using UnityEngine;

namespace PFS.UI.GameScene.gameScene
{
    public class GameScene : MonoBehaviour
    {
        [SerializeField] private PopupBase _pausePopup;
        [SerializeField] private PopupBase _gameOverPopup;
        [SerializeField] private TextMeshProUGUI _scoreText;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _pausePopup.OnOpenPopup();
            }

            CheckScore();
        }

        public void OpenGameOverPopup(int msg)
        {
            _gameOverPopup.OnOpenPopup(msg);
        }

        private void CheckScore()
        {
            if (Convert.ToUInt64(_scoreText.text) == GameManager.totalScore)
            {
                return;
            }

            _scoreText.text = GameManager.totalScore.ToString();
        }
    }

}
