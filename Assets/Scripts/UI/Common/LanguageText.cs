using PFS.Data.StaticData.staticSettingsData;
using PFS.Data.StaticData.staticUIStringData;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PFS.UI.Common.languageText
{
    public class LanguageText : MonoBehaviour
    {
        [SerializeField] private string _textKey;
        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            Debug.Log(StaticUIStringData.uiString[_textKey]);
            _text.text = StaticUIStringData.uiString[_textKey];
        }
    }
}
