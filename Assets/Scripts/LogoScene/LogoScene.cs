using PFS.Data.StaticData.staticSettingsData;
using PFS.Util.sceneFader;
using System.Collections;
using UnityEngine;

namespace PFS.LogoScene.logoScene
{
    public class LogoScene : MonoBehaviour
    {
        private void Start()
        {
            print(StaticSettingsData.language);
            StartCoroutine(GameStart());
        }

        IEnumerator GameStart()
        {
            SceneFader.instance.FadeIn();
            yield return new WaitForSeconds(4.0f);
            SceneFader.instance.FadeOut();
        }
    }

}
