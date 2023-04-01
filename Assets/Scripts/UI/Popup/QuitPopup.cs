using PFS.UI.Common.popupBase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PFS.UI.Popup.quitPopup
{
    public class QuitPopup : PopupBase
    {
        public override void OnOpenPopup(int msg = -1)
        {
            base.OnOpenPopup();
        }

        public override void OnClosePopup()
        {
            base.OnClosePopup();
        }

        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
