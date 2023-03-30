using PFS.UI.Common.popupBase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PFS.UI.GameScene.gameScene
{
    public class GameScene : MonoBehaviour
    {
        [SerializeField] private PopupBase _pausePopup;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _pausePopup.gameObject.SetActive(true);
                _pausePopup.OnOpenPopup();
            }
        }
    }

}
