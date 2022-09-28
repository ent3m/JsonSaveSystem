using UnityEditor;
using UnityEngine;

namespace JsonSave
{
    public class MonoSaveable : MonoBehaviour
    {
        [SerializeField]
        protected string keyID;
        protected int sceneID;
        protected SaveManager saveManager;

        protected virtual void OnEnable()
        {
            sceneID = gameObject.scene.buildIndex;
            saveManager = ResourceManager.SaveManager;
            SaveManager.LoadGame += ReceiveData;
            SaveManager.SaveGame += SendData;
        }

        protected virtual void OnDestroy()
        {
            SaveManager.LoadGame -= ReceiveData;
            SaveManager.SaveGame -= SendData;
        }

        protected virtual void ReceiveData(int sceneIndex)
        {
            Debug.LogWarning($"{nameof(ReceiveData)} is not implemented in {GetType()} component of {name} gameobject.");
        }

        protected virtual void SendData(int sceneIndex)
        {
            Debug.LogWarning($"{nameof(SendData)} is not implemented in {GetType()} component of {name} gameobject.");
        }

#if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            if (keyID == "" || keyID == null)
            {
                var id = GlobalObjectId.GetGlobalObjectIdSlow(this);
                keyID = id.assetGUID.ToString() + id.targetObjectId;
            }
        }
#endif
    }
}