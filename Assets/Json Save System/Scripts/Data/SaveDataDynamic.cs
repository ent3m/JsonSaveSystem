using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JsonSave
{
    public class SaveDataDynamic
    {
        public Dictionary<string, List<string>>[] Objects;

        public SaveDataDynamic(int sceneCount)
        {
            Objects = new Dictionary<string, List<string>>[sceneCount];
            for (int i = 0; i < Objects.Length; i++)
            {
                Objects[i] = new Dictionary<string, List<string>>();
            }
        }

        [JsonConstructor]
        public SaveDataDynamic() { }
    }
}