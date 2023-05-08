using PFS.Data.StaticData.staticUserData;
using PFS.UI.Common.popupBase;
using PFS.Util.sceneFader;
using PFS.Util.sceneLoader;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

namespace PFS.UI.LobbyScene.lobbyScene
{
    public class LobbyScene : MonoBehaviour
    {
        [SerializeField] private string GAME_SCENE_NAME;
        [SerializeField] private TextMeshProUGUI _highScoreText;

        private void Start()
        {
            SetupHighScore();
        }

        public void GameStart()
        {
            StartCoroutine(GameStartCoroutine());
        }

        IEnumerator GameStartCoroutine()
        {
            SceneFader.instance.FadeOut();
            yield return new WaitForSeconds(SceneFader.instance.fadeTime);
            SceneLoader.instance.LoadSceneAsync(SceneLoader.instance.GAME_SCENE_NAME);
        }

        public void OpenPopup(PopupBase popup)
        {
            popup.gameObject.SetActive(true);
            popup.OnOpenPopup();
        }

        private void SetupHighScore()
        {
            _highScoreText.text = $"{LocalizationSettings.StringDatabase.GetLocalizedString("UI_String_Table", "YOUR_HIGH_SCORE", LocalizationSettings.SelectedLocale)} : {StaticUserData.maxScore}";
        }
    }
}
