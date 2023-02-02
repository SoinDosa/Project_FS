using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace PFS.Util.sceneFader
{
    public class SceneFader : MonoBehaviour
    {
        public static SceneFader instance;
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

        public void FadeIn()
        {
            _fadeImage.DOFade(0, 2f).SetEase(Ease.Linear);
        }

        public void FadeOut()
        {
            _fadeImage.DOFade(1, 2f).SetEase(Ease.Linear);
        }
    }

}
