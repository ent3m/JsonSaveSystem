using UnityEngine;
using JsonSave;

public class SavingHandler : MonoBehaviour
{
    [SerializeField]
    string filePath = "save.sav";
    SaveManager saveManager;

    private void OnEnable()
    {
        saveManager = ResourceManager.SaveManager;
        saveManager.FilePath = filePath;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            saveManager.SaveAllScenes();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            saveManager.LoadAllScenes();
        }
    }
}