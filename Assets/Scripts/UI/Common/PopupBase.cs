using PFS.Enum.sfxEnum;
using PFS.Util.soundManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PFS.UI.Common.popupBase
{
    public class PopupBase : MonoBehaviour
    {
        public virtual void OnOpenPopup(int msg = -1)
        {
            this.gameObject.SetActive(true);
            SoundManager.instance?.PlaySFX(SFXEnum.CLICK_SOUND);
        }

        public virtual void OnClosePopup()
        {
            SoundManager.instance?.PlaySFX(SFXEnum.CLICK_SOUND);
            this.gameObject.SetActive(false);
        }
    }
}
