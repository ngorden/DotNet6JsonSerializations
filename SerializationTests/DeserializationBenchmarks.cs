using System.Text;
using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using Bogus;

namespace SerializationTests;

[MemoryDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
public class DeserializationBenchmarks
{
    private readonly JsonSerializerOptions? _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    private string _peopleAsText = string.Empty;


    [GlobalSetup]
    public void Setup()
    {
        Faker<Person> faker = new();
        Randomizer.Seed = new Random(420);
        var people = faker
            .RuleFor(x => x.FirstName, x => x.Person.FirstName)
            .RuleFor(x => x.LastName, x => x.Person.LastName)
            .Generate(1000);

        var memoryStream = new MemoryStream();
        var jsonWriter = new Utf8JsonWriter(memoryStream);
        JsonSerializer.Serialize(jsonWriter, people, _options);
        _peopleAsText = Encoding.UTF8.GetString(memoryStream.ToArray());
    }

    [Benchmark(Baseline = true)]
    public List<Person>? ClassicDeserializer()
    {
        return JsonSerializer.Deserialize<List<Person>>(_peopleAsText, _options);
    }

    [Benchmark]
    public List<Person> GeneratedSerializer()
    {
        return (List<Person>) (JsonSerializer.Deserialize(_peopleAsText, PeopleJsonContext.Default.IEnumerablePerson) ??
               new List<Person>());
    }
}