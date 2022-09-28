using JsonSave;

public class SaveableObject : MonoSaveable
{
    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    protected override void ReceiveData(int sceneIndex)
    {
        if (sceneIndex == -1 || sceneIndex == sceneID)
        {
            var data = saveManager.ReceiveData<TransformData>(sceneID, keyID);
            TransformData.SetTransform(data, this.transform);
        }
    }

    protected override void SendData(int sceneIndex)
    {
        if (sceneIndex == -1 || sceneIndex == sceneID)
        {
            var data = new TransformData(transform);
            saveManager.SendData<TransformData>(data, sceneID, keyID);
        }
    }
}