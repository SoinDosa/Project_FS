using Newtonsoft.Json;
using PFS.Data.Common.dataLoader;
using PFS.Data.Common.dataSaver;
using PFS.Data.DataStructures.settingsDataStructure;
using PFS.Data.StaticData.staticSettingsData;
using PFS.Enum.sfxEnum;
using PFS.UI.Common.popupBase;
using PFS.Util.soundManager;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
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
        private DataSaver _dataSaver = new();
        private bool isLanguageChanging;

        public override void OnOpenPopup(int msg = -1)
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
            StartCoroutine(ChangeLanguageCoroutine());
            SoundManager.instance.PlaySFX(SFXEnum.CLICK_SOUND);
        }

        IEnumerator ChangeLanguageCoroutine()
        {
            isLanguageChanging = true;

            yield return LocalizationSettings.InitializationOperation;
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[StaticSettingsData.language];

            isLanguageChanging = false;
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
