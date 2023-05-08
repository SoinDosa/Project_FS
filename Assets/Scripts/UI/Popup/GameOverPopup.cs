using PFS.Data.Common.dataSaver;
using PFS.Data.DataStructures.userDataStructure;
using PFS.Data.StaticData.staticUserData;
using PFS.GamePlay.ObjectPooling.objectPool;
using PFS.GamePlay.Rule.gameManager;
using PFS.GamePlay.Rule.timer;
using PFS.UI.Common.popupBase;
using PFS.Util.Ads.rewardAdsManager;
using PFS.Util.sceneFader;
using PFS.Util.sceneLoader;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace PFS.UI.Popup.gameOverPopup
{
    public class GameOverPopup : PopupBase
    {
        [SerializeField] private string USERS_DATA_NAME;
        [SerializeField] private float ADDITIONAL_TIME;
        [SerializeField] private Button _continueButton;
        [SerializeField] private TextMeshProUGUI _gameOverReasonText;
        private int _gameOverReason;
        private ObjectPool _objectPool;
        private RewardAdsManager _rewardAdsManager; 
        private DataSaver _dataSaver = new();

        private void Awake()
        {
            _objectPool = GameObject.Find("PlayerPool").GetComponent<ObjectPool>();
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
            SaveUsersData();
            StartCoroutine(GoToLobbyCoroutine());
        }

        public void ContinueGame()
        {
            switch (_gameOverReason)
            {
                case 0:
                    Timer.remainTime += ADDITIONAL_TIME;
                    //var obj = _playerPool.GenerateObject();
                    var obj = _objectPool.PullObject();
                    obj.transform.position = Camera.main.transform.position;
                    break;
                case 1:
                    Timer.remainTime += ADDITIONAL_TIME;
                    break;
            }

            GameManager.isGameOver = false;
            _continueButton.interactable = false;
            OnClosePopup();
        }

        IEnumerator GoToLobbyCoroutine()
        {
            SceneFader.instance.FadeOut();
            yield return new WaitForSeconds(SceneFader.instance.fadeTime);
            SceneLoader.instance.LoadSceneAsync(SceneLoader.instance.LOBBY_SCENE_NAME);
        }

        public void SaveUsersData()
        {
            UserDataStructure structure;
            string jsonData;

            structure.is_newbie = false;
            if (GameManager.totalScore > StaticUserData.maxScore)
            {
                structure.max_score = StaticUserData.maxScore = GameManager.totalScore;
            }
            else
            {
                structure.max_score = StaticUserData.maxScore;
            }
            
            jsonData = JsonUtility.ToJson(structure);

            _dataSaver.JsonStringSave($"{Application.persistentDataPath}/{USERS_DATA_NAME}", jsonData);
        }
    }
}

