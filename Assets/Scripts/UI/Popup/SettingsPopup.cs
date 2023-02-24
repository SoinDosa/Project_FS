using Newtonsoft.Json;
using PFS.Data.Common.dataLoader;
using PFS.Data.Common.dataSaver;
using PFS.Data.DataStructures.settingsDataStructure;
using PFS.Data.StaticData.staticSettingsData;
using PFS.Data.StaticData.staticUIStringData;
using PFS.UI.Common.popupBase;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PFS.UI.Popup.settingsPopup
{
    public class SettingsPopup : PopupBase
    {
        [SerializeField] private string SETTINGS_DATA_NAME;
        [SerializeField] private string UI_STRING_DATA_NAME;
        [SerializeField] private Toggle _bgmToggle;
        [SerializeField] private Toggle _efxToggle;
        [SerializeField] private TMP_Dropdown _languageDropdown;
        private string _uiStringDataPath;
        private DataSaver _dataSaver = new();
        private DataLoader _dataLoader = new();

        private void Awake()
        {
            _uiStringDataPath = $"{Application.streamingAssetsPath}/{UI_STRING_DATA_NAME}";
        }

        public override void OnOpenPopup()
        {
            _bgmToggle.isOn = StaticSettingsData.isOnBGM;
            _efxToggle.isOn = StaticSettingsData.isOnEFX;
            _languageDropdown.value = StaticSettingsData.language;
        }

        public override void OnClosePopup()
        {
            SaveSettingsData();
            base.OnClosePopup();
        }

        public void ChangeIsOnBGM()
        {
            StaticSettingsData.isOnBGM = _bgmToggle.isOn;
        }

        public void ChangeIsOnEFX()
        {
            StaticSettingsData.isOnEFX = _efxToggle.isOn;
        }

        public void ChangeLanguage()
        {
            StaticSettingsData.language = _languageDropdown.value;
            SetupUIStringData();
            LanguageActionContainer.LanguageChange();
        }

        private void SetupUIStringData()
        {
            string jsonData;

            switch (StaticSettingsData.language)
            {
                case 0:
                    jsonData = _dataLoader.GetJsonString($"{_uiStringDataPath}_KOR.json");
                    break;
                case 1:
                    jsonData = _dataLoader.GetJsonString($"{_uiStringDataPath}_ENG.json");
                    break;
                default:
                    jsonData = null;
                    break;
            }

            StaticUIStringData.uiString = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);
        }

        private void SaveSettingsData()
        {
            SettingsDataStructure structure;
            string jsonData;

            structure.is_on_bgm = _bgmToggle.isOn;
            structure.is_on_efx = _efxToggle.isOn;
            structure.language = _languageDropdown.value;
            jsonData = JsonUtility.ToJson(structure);

            _dataSaver.JsonStringSave($"{Application.persistentDataPath}/{SETTINGS_DATA_NAME}", jsonData);
        }
    }
}
