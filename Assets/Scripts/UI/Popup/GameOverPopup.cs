using PFS.UI.Common.popupBase;
using PFS.Util.sceneFader;
using PFS.Util.sceneLoader;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PFS.UI.Popup.gameOverPopup
{
    public class GameOverPopup : PopupBase
    {
        [SerializeField] private TextMeshProUGUI _reasonForGameover;

        public override void OnOpenPopup(string msg = null)
        {
            base.OnOpenPopup();
            _reasonForGameover.text = msg;
            Time.timeScale = 0f;
        }

        public override void OnClosePopup()
        {
            base.OnClosePopup();
            Time.timeScale = 1f;
        }

        public void GoToLobby()
        {
            Time.timeScale = 1f;
            StartCoroutine(GoToLobbyCoroutine());
        }

        IEnumerator GoToLobbyCoroutine()
        {
            SceneFader.instance.FadeOut();
            yield return new WaitForSeconds(SceneFader.instance.fadeTime);
            SceneLoader.instance.LoadSceneAsync(SceneLoader.instance.LOBBY_SCENE_NAME);
        }
    }
}

