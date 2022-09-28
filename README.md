# JsonSaveSystem
JsonSaveSystem is a save system for Unity that uses the System.Text.Json namespace provided by .NET.
It is designed to be versatile, easy to use, and easy to maintain.
It has built-in safety code to ensure correct utilization of the library.

# Features:
- Each component(script) has its own GUID. Each component is serialized separately.
- One gameobject can have multiple serialized components. These components can be of the same type.
- The system saves objects by scene, meaning each scene can be loaded and unloaded individually. Supports multi-scene setup.
- The data structure saves all scenes into one file, making it simple to transfer and to keep track of save file.
- Data is serialized to Utf8 bytes, which allows encryption and modification before writing to file.

# Why System.Text.Json?
- System.Text.Json is a fully featured Json Serializer and Deserializer. It supports most data structures and fields, in contrast to Unity's JsonUtility which cannot handle those types.
- It offers excellent performance compared to other C# Json Serializers, such as Json.NET and LitJson, only losing to Unity's JsonUtility.
- It is built by Microsoft, hence is guaranteed to be stable.

# How to use?
1. Attach SaveManager component to a persistent gameobject.
2. Create a script that handles saving by interacting with SaveManager's API. 
3. Have the component that needs to be serialized inherit from SaveableMono instead of MonoBehaviour.
4. Implement saving and loading logic for that component.
5. See Examples folder for more info.

# Performance
- Compared to Json.NET (10k iterations):
1. ~2.13x faster serialization(120ms vs 254ms)
2. ~1.27x faster deserialization than Json.NET (175ms vs 223ms)
3. ~51% less GC allocation during serialization (9.5MB vs 19.3MB)
4. ~70% less GC allocation during deserialization (9.4MB vs 31.6MB)

- Compared to JsonUtility (10k iterations):
1. ~2x slower serialization (120ms vs 58ms)
2. ~1.1x slower deserialization (175ms vs 153ms)
3. ~3.1x more GC allocation during serialization (9.5MB vs 3MB)
4. ~2.4x more GC allocation during deserialization (9.4MB vs 3.9MB)

- Due to technical limitations in the Unity Engine, source generation mode is not available, and reflection mode is used.
Once Unity Engine updates their runtime to .NET 6 and source generation mode is supported, performance should be on par with JsonUtility.

Planned features:
- Support for gameobjects that are dynamically constructed at runtime
- Custom scene mapping that allows spitting save file into multiple smaller files

Known bugs:
- none
