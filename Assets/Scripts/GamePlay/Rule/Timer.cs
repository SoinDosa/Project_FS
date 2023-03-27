using PFS.GamePlay.Rule.gameOverChecker;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PFS.GamePlay.Rule.timer
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float INITIAL_TIME;
        [SerializeField] private TextMeshProUGUI _time;
        private float _remainTime;
        private bool _isGameOver;

        private void Awake()
        {
            Application.targetFrameRate = 45;
            _remainTime = INITIAL_TIME;
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
                Debug.Log("Time Out");
            }
        }

        private void UpdateTime()
        {
            _time.text = $"{(int)_remainTime}";
        }
    }
}
