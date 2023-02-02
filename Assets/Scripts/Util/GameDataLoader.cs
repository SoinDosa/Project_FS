using Newtonsoft.Json;
using PFS.Data.Common.dataLoader;
using PFS.Data.DataStructures.settingsDataStructure;
using PFS.Data.DataStructures.userDataStructure;
using PFS.Data.StaticData.staticSettingsData;
using PFS.Data.StaticData.staticUIStringData;
using PFS.Data.StaticData.staticUserData;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace PFS.Util.gameDataLoader
{
    public class GameDataLoader : MonoBehaviour
    {
        [SerializeField] private string SETTINGS_DATA_NAME;
        [SerializeField] private string USER_DATA_NAME;
        [SerializeField] private string UI_STRING_DATA_NAME;
        private string _settingsDataPath;
        private string _userDataPath;
        private string _uiStringDataPath;
        private DataLoader _dataLoader = new();

        // Start is called before the first frame update
        void Start()
        {
            _settingsDataPath = $"{Application.persistentDataPath}/{SETTINGS_DATA_NAME}";
            _userDataPath = $"{Application.persistentDataPath}/{USER_DATA_NAME}";
            _uiStringDataPath = $"{Application.streamingAssetsPath}/{UI_STRING_DATA_NAME}";
            SetupData();
        }

        private void SetupData()
        {
            SetupSettingsData();
            SetupUserData();
            SetupUIStringData();
        }

        private void SetupSettingsData()
        {
            if(!File.Exists(_settingsDataPath))
            {
                return;
            }
            string jsonData = _dataLoader.GetJsonString(_settingsDataPath);
            SettingsDataStructure dataStructure = JsonUtility.FromJson<SettingsDataStructure>(jsonData);

            StaticSettingsData.isOnBGM = dataStructure.is_on_bgm;
            StaticSettingsData.isOnEFX = dataStructure.is_on_efx;
            StaticSettingsData.language = dataStructure.language;
        }

        private void SetupUserData()
        {
            if (!File.Exists(_userDataPath))
            {
                return;
            }
            string jsonData = _dataLoader.GetJsonString(_userDataPath);
            UserDataStructure dataStructure = JsonUtility.FromJson<UserDataStructure>(jsonData);

            StaticUserData.isNewbie = dataStructure.is_newbie;
            StaticUserData.maxScore = dataStructure.max_score;
        }

        private void SetupUIStringData()
        {
            switch(StaticSettingsData.language)
            {
                case 0:
                    _uiStringDataPath = $"{_uiStringDataPath}_KOR.json";
                    break;
                case 1:
                    _uiStringDataPath = $"{_uiStringDataPath}_ENG.json";
                    break;
            }
            string jsonData = _dataLoader.GetJsonString(_uiStringDataPath);

            StaticUIStringData.uiString = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);
        }
    }
}


