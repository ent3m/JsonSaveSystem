using UnityEngine;
using UnityEngine.AddressableAssets;

//  Helper class for cleaning up addressable gameobjects
//  Attach this script to an instantiated addressable gameobject for automatic cleanup
public class AddressableSelfCleanup : MonoBehaviour
{
    private void OnDestroy()
    {
        Addressables.ReleaseInstance(gameObject);
    }
}