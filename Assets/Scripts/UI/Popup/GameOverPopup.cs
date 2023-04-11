using PFS.GamePlay.ObjectPooling.playerPool;
using PFS.GamePlay.Rule.gameOverChecker;
using PFS.GamePlay.Rule.timer;
using PFS.UI.Common.popupBase;
using PFS.Util.Ads.rewardAdsManager;
using PFS.Util.sceneFader;
using PFS.Util.sceneLoader;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace PFS.UI.Popup.gameOverPopup
{
    public class GameOverPopup : PopupBase
    {
        [SerializeField] private float ADDITIONAL_TIME;
        [SerializeField] private Button _continueButton;
        [SerializeField] private TextMeshProUGUI _gameOverReasonText;
        private int _gameOverReason;
        private PlayerPool _playerPool;
        private RewardAdsManager _rewardAdsManager;

        private void Awake()
        {
            _playerPool = FindObjectOfType<PlayerPool>();
            _rewardAdsManager = FindObjectOfType<RewardAdsManager>();
            _rewardAdsManager.OnGameContinue += ContinueGame;
        }

        public override void OnOpenPopup(int msg = -1)
        {
            base.OnOpenPopup();
            _gameOverReason = msg;
            switch (_gameOverReason)
            {
                case 0:
                    _gameOverReasonText.text = LocalizationSettings.StringDatabase.GetLocalizedString("Reason_For_Gameover", "ALLDIE", LocalizationSettings.SelectedLocale);
                    break;
                case 1:
                    _gameOverReasonText.text = LocalizationSettings.StringDatabase.GetLocalizedString("Reason_For_Gameover", "TIMEOUT", LocalizationSettings.SelectedLocale);
                    break;
            }
            Time.timeScale = 0f;
        }

        public override void OnClosePopup()
        {
            Time.timeScale = 1f;
            base.OnClosePopup();
        }

        public void GoToLobby()
        {
            Time.timeScale = 1f;
            StartCoroutine(GoToLobbyCoroutine());
        }

        public void ContinueGame()
        {
            switch (_gameOverReason)
            {
                case 0:
                    Timer.remainTime += ADDITIONAL_TIME;
                    var obj = _playerPool.GenerateObject();
                    obj.transform.position = Camera.main.transform.position;
                    break;
                case 1:
                    Timer.remainTime += ADDITIONAL_TIME;
                    break;
            }

            GameOverChecker.isGameOver = false;
            _continueButton.interactable = false;
            OnClosePopup();
        }

        IEnumerator GoToLobbyCoroutine()
        {
            SceneFader.instance.FadeOut();
            yield return new WaitForSeconds(SceneFader.instance.fadeTime);
            SceneLoader.instance.LoadSceneAsync(SceneLoader.instance.LOBBY_SCENE_NAME);
        }
    }
}

