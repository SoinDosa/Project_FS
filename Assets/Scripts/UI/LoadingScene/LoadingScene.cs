using PFS.Util.sceneFader;
using PFS.Util.sceneLoader;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PFS.UI.LoadingScene.loadingScene
{
    public class LoadingScene : MonoBehaviour
    {
        [SerializeField] private Image _progressBar;

        void Start()
        {
            SceneFader.instance.ActiveOff();
            StartCoroutine(LoadAsyncSceneCoroutine());
        }

        IEnumerator LoadAsyncSceneCoroutine()
        {
            AsyncOperation op = SceneManager.LoadSceneAsync(SceneLoader.instance.sceneName);

            op.allowSceneActivation = false;
            while(!op.isDone)
            {
                yield return null;
                if (op.progress < 0.9f)
                {
                    _progressBar.fillAmount = op.progress;
                }
                else
                {
                    _progressBar.fillAmount = 1.0f;
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
