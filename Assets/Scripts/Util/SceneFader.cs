using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace PFS.Util.sceneFader
{
    public class SceneFader : MonoBehaviour
    {
        public static SceneFader instance;
        public float fadeTime;
        [SerializeField] private Image _fadeImage;

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

        public void ActiveOff()
        {
            _fadeImage.gameObject.SetActive(false);
        }

        public void FadeIn()
        {
            _fadeImage.gameObject.SetActive(true);
            _fadeImage.color = new Vector4(0, 0, 0, 1);
            _fadeImage.DOFade(0, fadeTime).SetEase(Ease.Linear);
        }

        public void FadeOut()
        {
            _fadeImage.DOFade(1, fadeTime).SetEase(Ease.Linear);
        }
    }
}