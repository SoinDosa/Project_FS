using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PFS.UI.Common.popupBase
{
    public class PopupBase : MonoBehaviour
    {
        public virtual void OnOpenPopup() { }

        public virtual void OnClosePopup()
        {
            this.gameObject.SetActive(false);
        }
    }
}
