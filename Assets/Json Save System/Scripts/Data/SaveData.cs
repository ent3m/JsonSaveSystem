using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JsonSave
{
    public class SaveData
    {
        public Dictionary<string, string>[] Objects;

        public SaveData(int sceneCount)
        {
            Objects = new Dictionary<string, string>[sceneCount];
            for (int i = 0; i < Objects.Length; i++)
            {
                Objects[i] = new Dictionary<string, string>();
            }
        }

        [JsonConstructor]
        public SaveData() { }
    }
}