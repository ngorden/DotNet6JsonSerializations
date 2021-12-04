using System.Text;
using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using Bogus;

namespace SerializationTests;

[MemoryDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
public class SerializationBenchmarks
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    private List<Person> _people = new();

    [GlobalSetup]
    public void Setup()
    {
        Faker<Person> faker = new();
        Randomizer.Seed = new Random(420);
        _people = faker
            .RuleFor(x => x.FirstName, x => x.Person.FirstName)
            .RuleFor(x => x.LastName, x => x.Person.LastName)
            .Generate(1000);
    }

    [BenchmarkCategory("Stream"), Benchmark(Baseline = true)]
    public MemoryStream ClassicSerializer()
    {
        var memoryStream = new MemoryStream();
        var jsonWriter = new Utf8JsonWriter(memoryStream);
        JsonSerializer.Serialize(jsonWriter, _people, _options);
        return memoryStream;
    }

    [BenchmarkCategory("Stream"), Benchmark]
    public MemoryStream GeneratedSerializer()
    {
        var memoryStream = new MemoryStream();
        var jsonWriter = new Utf8JsonWriter(memoryStream);
        JsonSerializer.Serialize(jsonWriter, _people, PeopleJsonContext.Default.IEnumerablePerson);
        return memoryStream;
    }

    [BenchmarkCategory("String"), Benchmark(Baseline = true)]
    public string ClassicSerializer_AsString()
    {
        var memoryStream = ClassicSerializer();
        return Encoding.UTF8.GetString(memoryStream.ToArray());
    }

    [BenchmarkCategory("String"), Benchmark]
    public string GeneratedSerializer_AsString()
    {
        var memoryStream = GeneratedSerializer();
        return Encoding.UTF8.GetString(memoryStream.ToArray());
    }
}