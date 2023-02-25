using PFS.Data.StaticData.staticSettingsData;
using PFS.Enum.efxEnum;
using PFS.Util.sceneFader;
using PFS.Util.sceneLoader;
using PFS.Util.soundManager;
using System.Collections;
using UnityEngine;

namespace PFS.UI.LogoScene.logoScene
{
    public class LogoScene : MonoBehaviour
    {
        [SerializeField] private float _waitTime;

        private void Start()
        {
            StartCoroutine(GameStart());
        }

        IEnumerator GameStart()
        {
            SceneFader.instance.FadeIn();
            SoundManager.instance.PlayEFX(EFXEnum.LOGO_ON);
            yield return new WaitForSeconds(SceneFader.instance.fadeTime + _waitTime);
            SceneFader.instance.FadeOut();
            yield return new WaitForSeconds(SceneFader.instance.fadeTime);
            SceneLoader.instance.LoadSceneAsync("LobbyScene");
        }
    }

}
