using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PFS.Util.sceneLoader
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader instance;
        public string sceneName;
        [SerializeField] private string _loadSceneName;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void LoadSceneAsync(string sceneName)
        {
            this.sceneName = sceneName;
            SceneManager.LoadScene(_loadSceneName);
        }
    }
}