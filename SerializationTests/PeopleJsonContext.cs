using System.Text.Json.Serialization;

namespace SerializationTests;

[JsonSerializable(typeof(IEnumerable<Person>))]
[JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Default,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
public partial class PeopleJsonContext : JsonSerializerContext
{
}