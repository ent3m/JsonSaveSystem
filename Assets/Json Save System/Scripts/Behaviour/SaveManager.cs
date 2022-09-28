using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.Experimental.GraphView;

namespace JsonSave
{
    public class SaveManager : MonoBehaviour
    {
        static SaveData SaveData;
        static SaveDataDynamic SaveDataDynamic;
        static JsonSerializerOptions option;

        public static event Action<int> SaveGame;
        public static event Action<int> LoadGame;

        [SerializeField] string saveFolder;
        public string FilePath { private get; set; }

        private void Awake()
        {
            ResourceManager.SaveManager = this;
            InitiateVariables();
        }

        public void InitiateVariables()
        {
            if (SaveData == null)
            {
                SaveData = new SaveData(SceneManager.sceneCountInBuildSettings);
            }
            if (SaveDataDynamic == null)
            {
                SaveDataDynamic = new SaveDataDynamic(SceneManager.sceneCountInBuildSettings);
            }
            if (option == null)
            {
                option = new JsonSerializerOptions { IncludeFields = true };
            }
        }

        public void SendData<T>(T data, int sceneIndex, string key)
        {
            var result = JsonSerializer.Serialize<T>(data, option);

            if (SaveData.Objects[sceneIndex].TryGetValue(key, out _))
            {
                SaveData.Objects[sceneIndex][key] = result;
            }
            else
            {
                SaveData.Objects[sceneIndex].Add(key, result);
            }
        }

        public T ReceiveData<T>(int sceneIndex, string key)
        {
            var data = SaveData.Objects[sceneIndex][key];
            return JsonSerializer.Deserialize<T>(data, option);
        }

        public void SendDataDynamic<T>(T data, int sceneIndex, string address)
        {
            var result = JsonSerializer.Serialize<T>(data, option);
            if (!SaveDataDynamic.Objects[sceneIndex].TryGetValue(address, out _))
            {
                SaveDataDynamic.Objects[sceneIndex].Add(address, new List<string>());
            }
            SaveDataDynamic.Objects[sceneIndex][address].Add(result);
        }

        public void SaveScene(int sceneIndex)
        {
            SaveGame?.Invoke(sceneIndex);
            var buffer = JsonSerializer.SerializeToUtf8Bytes(SaveData, option);
            File.WriteAllBytes(saveFolder + FilePath, buffer);
        }

        public void LoadScene(int sceneIndex)
        {
            var buffer = File.ReadAllBytes(saveFolder + FilePath);
            SaveData = JsonSerializer.Deserialize<SaveData>(buffer, option);
            LoadGame?.Invoke(sceneIndex);
        }

        public void SaveAllScenes()
        {
            SaveScene(-1);
        }

        public void LoadAllScenes()
        {
            LoadScene(-1);
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (saveFolder == "" || saveFolder == null)
            {
                saveFolder = Application.persistentDataPath + "/Saves/";
            }
        }
#endif
    }
}