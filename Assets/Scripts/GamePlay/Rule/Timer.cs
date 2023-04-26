using PFS.GamePlay.Rule.gameOverChecker;
using PFS.UI.GameScene.gameScene;
using TMPro;
using UnityEngine;

namespace PFS.GamePlay.Rule.timer
{
    public class Timer : MonoBehaviour
    {
        public static float remainTime;

        [SerializeField] private float INITIAL_TIME;
        [SerializeField] private TextMeshProUGUI _time;
        private bool _isGameOver;
        private GameScene _gameScene;

        private void Awake()
        {
            GameOverChecker.isGameOver = false;
            Application.targetFrameRate = 45;
            remainTime = INITIAL_TIME;
        }

        private void Start()
        {
            _gameScene = FindObjectOfType<GameScene>();
        }

        private void Update()
        {
            if (GameOverChecker.isGameOver == false)
            {
                remainTime -= Time.deltaTime;
                UpdateTime();
                CheckGameOver();
            }
        }

        private void CheckGameOver()
        {
            if (remainTime < 1)
            {
                GameOverChecker.isGameOver = true;
                _gameScene.OpenGameOverPopup(1);
                Debug.Log("Time Out");
            }
        }

        private void UpdateTime()
        {
            _time.text = $"{(int)remainTime}";
        }
    }
}
