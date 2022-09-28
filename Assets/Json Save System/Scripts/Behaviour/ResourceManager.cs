using System;
using System.Net;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace JsonSave
{
    public class ResourceManager
    {
        //	Enable if inherit from Monobehaviour and is in Resources folder
        #region MONO RESOURCES
        //public static ResourceManager Instance
        //{ get; private set; }

        //public ResourceManager()
        //{
        //	Instance = this;
        //}
        #endregion

        //  Enable if inherit from Monobehaviour and is an Addressable
        #region MONO ADDRESSABLE
        //private static ResourceManager instance;
        //public static ResourceManager Instance
        //{
        //	get
        //	{
        //		if (instance == null)
        //		{
        //			var handle = Addressables.LoadAssetAsync<GameObject>("ResourceManager");
        //			handle.WaitForCompletion();
        //			instance = handle.Result.GetComponent<ResourceManager>();
        //		}
        //		return instance;
        //	}
        //}
        #endregion

        //  Provide global access to SaveManager instance via static field
        #region NON-MONO STATIC
        private static SaveManager saveManager;
        public static SaveManager SaveManager
        {
            get
            {
                if (saveManager == null)
                {
                    if (GameObject.FindGameObjectWithTag("SaveManager") is var result && result != null)
                    {
                        saveManager = result.GetComponent<SaveManager>();
                        saveManager.InitiateVariables();
                    }
                    else
                    {
                        throw new NullReferenceException("No Save Manager found. There must be one Save Manager in the scene.");
                    }
                }
                return saveManager;
            }
            set
            {
                if (saveManager == null) { saveManager = value; }
                else if (saveManager != value) { Debug.LogError("There should only be one Save Manager in the scene(s)."); }
            }
        }
        #endregion
    }
}