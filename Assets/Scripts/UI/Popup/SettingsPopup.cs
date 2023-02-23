using PFS.Data.Common.dataSaver;
using PFS.Data.DataStructures.settingsDataStructure;
using PFS.Data.StaticData.staticSettingsData;
using PFS.UI.Common.popupBase;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PFS.UI.Popup.settingsPopup
{
    public class SettingsPopup : PopupBase
    {
        [SerializeField] private string SETTINGS_DATA_NAME;
        [SerializeField] private Toggle _bgmToggle;
        [SerializeField] private Toggle _efxToggle;
        [SerializeField] private TMP_Dropdown _languageDropdown;
        private DataSaver _dataSaver = new();

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
