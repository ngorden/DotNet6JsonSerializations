using System.Text.Json.Serialization;

namespace SerializationTests;

/// <inheritdoc cref="PersonJsonContext" />
[JsonSerializable(typeof(Person))]
[JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Default,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
public partial class PersonJsonContext : JsonSerializerContext
{
}