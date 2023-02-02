using PFS.Data.StaticData.staticSettingsData;
using PFS.Util.sceneFader;
using PFS.Util.sceneLoader;
using System.Collections;
using UnityEngine;

namespace PFS.LogoScene.logoScene
{
    public class LogoScene : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(GameStart());
        }

        IEnumerator GameStart()
        {
            SceneFader.instance.FadeIn();
            yield return new WaitForSeconds(4.0f);
            SceneFader.instance.FadeOut();
            yield return new WaitForSeconds(3.0f);
            SceneLoader.instance.LoadSceneAsync("LobbyScene");
        }
    }

}
