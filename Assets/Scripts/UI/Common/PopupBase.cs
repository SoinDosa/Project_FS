using PFS.Enum.efxEnum;
using PFS.Util.soundManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PFS.UI.Common.popupBase
{
    public class PopupBase : MonoBehaviour
    {
        public virtual void OnOpenPopup()
        {
            SoundManager.instance.PlayEFX(EFXEnum.CLICK_SOUND);
        }

        public virtual void OnClosePopup()
        {
            SoundManager.instance.PlayEFX(EFXEnum.CLICK_SOUND);
            this.gameObject.SetActive(false);
        }
    }
}
