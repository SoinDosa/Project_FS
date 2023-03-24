using Newtonsoft.Json;
using PFS.Data.Common.dataLoader;
using PFS.Data.Common.dataSaver;
using PFS.Data.DataStructures.settingsDataStructure;
using PFS.Data.StaticData.staticSettingsData;
using PFS.Enum.sfxEnum;
using PFS.UI.Common.popupBase;
using PFS.Util.soundManager;
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
        [SerializeField] private Toggle _sfxToggle;
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
            base.OnOpenPopup();
            _bgmToggle.isOn = StaticSettingsData.isOnBGM;
            _sfxToggle.isOn = StaticSettingsData.isOnSFX;
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
            SoundManager.instance.SetBGM(StaticSettingsData.isOnBGM);
            SoundManager.instance.PlaySFX(SFXEnum.CLICK_SOUND);
        }

        public void ChangeIsOnSFX()
        {
            StaticSettingsData.isOnSFX = _sfxToggle.isOn;
            SoundManager.instance.SetSFX(StaticSettingsData.isOnSFX);
            SoundManager.instance.PlaySFX(SFXEnum.CLICK_SOUND);
        }

        public void ChangeLanguage()
        {
            StaticSettingsData.language = _languageDropdown.value;
            SoundManager.instance.PlaySFX(SFXEnum.CLICK_SOUND);
        }

        private void SaveSettingsData()
        {
            SettingsDataStructure structure;
            string jsonData;

            structure.is_on_bgm = _bgmToggle.isOn;
            structure.is_on_sfx = _sfxToggle.isOn;
            structure.language = _languageDropdown.value;
            jsonData = JsonUtility.ToJson(structure);

            _dataSaver.JsonStringSave($"{Application.persistentDataPath}/{SETTINGS_DATA_NAME}", jsonData);
        }
    }
}
