using System.Text.Json;
using BenchmarkDotNet.Running;
using SerializationTests;

var person = new Person {FirstName = "Nick", LastName = "Gorden"};

var serializerOptions = new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
var nickTextOld = JsonSerializer.Serialize(person, serializerOptions);
var nickTextNew = JsonSerializer.Serialize(person, PersonJsonContext.Default.Person);

var deserializedObject = JsonSerializer.Deserialize(nickTextNew, PersonJsonContext.Default.Person);
Console.WriteLine(nickTextNew);

BenchmarkRunner.Run<DeserializationBenchmarks>();
//BenchmarkRunner.Run<SerializationBenchmarks>();