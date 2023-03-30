using PFS.GamePlay.Rule.gameOverChecker;
using PFS.UI.GameScene.gameScene;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

namespace PFS.GamePlay.Rule.timer
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float INITIAL_TIME;
        [SerializeField] private TextMeshProUGUI _time;
        private float _remainTime;
        private bool _isGameOver;
        private GameScene _gameScene;

        private void Awake()
        {
            GameOverChecker.isGameOver = false;
            Application.targetFrameRate = 45;
            _remainTime = INITIAL_TIME;
        }

        private void Start()
        {
            _gameScene = FindObjectOfType<GameScene>();
        }

        private void Update()
        {
            if (GameOverChecker.isGameOver == false)
            {
                _remainTime -= Time.deltaTime;
                UpdateTime();
                CheckGameOver();
            }
        }

        private void CheckGameOver()
        {
            if (_remainTime < 1)
            {
                GameOverChecker.isGameOver = true;
                _gameScene.OpenGameOverPopup(LocalizationSettings.StringDatabase.GetLocalizedString("Reason_For_Gameover", "TIMEOUT", LocalizationSettings.SelectedLocale));
                Debug.Log("Time Out");
            }
        }

        private void UpdateTime()
        {
            _time.text = $"{(int)_remainTime}";
        }
    }
}
