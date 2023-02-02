using PFS.Util.sceneFader;
using System.Collections;
using System.Collections.Generic;
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
        }
    }

}
