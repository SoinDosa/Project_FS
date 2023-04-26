using UnityEngine;
using UnityEngine.SceneManagement;

namespace PFS.Util.sceneLoader
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader instance;
        public string sceneName;
        public string GAME_SCENE_NAME;
        public string LOBBY_SCENE_NAME;
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