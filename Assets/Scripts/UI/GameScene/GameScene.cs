using PFS.UI.Common.popupBase;
using UnityEngine;

namespace PFS.UI.GameScene.gameScene
{
    public class GameScene : MonoBehaviour
    {
        [SerializeField] private PopupBase _pausePopup;
        [SerializeField] private PopupBase _gameOverPopup;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _pausePopup.OnOpenPopup();
            }
        }

        public void OpenGameOverPopup(int msg)
        {
            _gameOverPopup.OnOpenPopup(msg);
        }
    }

}
