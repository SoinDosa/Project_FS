using PFS.UI.Common.popupBase;
using PFS.Util.sceneFader;
using PFS.Util.sceneLoader;
using System.Collections;
using UnityEngine;

namespace PFS.UI.LobbyScene.lobbyScene
{
    public class LobbyScene : MonoBehaviour
    {
        [SerializeField] private string GAME_SCENE_NAME;

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
    }
}
