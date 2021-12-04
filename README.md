# JSON Serialization in .NET 6

This code isn't mine. [Elfocrash](github.com/elfocrash) demonstrated this in a video showcasing .NET 6 features. I just wanted to be able to share it with my coworkers.

# Benchmark Summaries 
## Executed in Release Mode(1,000 Samples)

### Deserialization Benchmark

|              Method |     Mean |   Error |   StdDev | Ratio | RatioSD |   Gen 0 |  Gen 1 | Allocated |
|-------------------- |---------:|--------:|---------:|------:|--------:|--------:|-------:|----------:|
| ClassicDeserializer | 455.8 us | 9.02 us | 20.91 us |  1.00 |    0.00 | 28.8086 | 9.2773 |    120 KB |
| GeneratedSerializer | 448.5 us | 8.81 us | 11.14 us |  0.98 |    0.05 | 28.3203 | 8.7891 |    120 KB |

### Serialization Benchmark

|                       Method | Categories |     Mean |   Error |  StdDev | Ratio |   Gen 0 |   Gen 1 |   Gen 2 | Allocated |
|----------------------------- |----------- |---------:|--------:|--------:|------:|--------:|--------:|--------:|----------:|
|            ClassicSerializer |     Stream | 249.7 us | 2.65 us | 2.48 us |  1.00 | 37.1094 | 11.7188 |       - |    155 KB |
|          GeneratedSerializer |     Stream | 150.0 us | 0.98 us | 0.92 us |  0.60 | 37.3535 |  0.4883 |       - |    154 KB |
|                              |            |          |         |         |       |         |         |         |           |
|   ClassicSerializer_AsString |     String | 411.6 us | 6.53 us | 5.10 us |  1.00 | 53.7109 | 26.8555 | 26.8555 |    282 KB |
| GeneratedSerializer_AsString |     String | 369.2 us | 3.23 us | 2.52 us |  0.90 | 53.7109 | 26.8555 | 26.8555 |    281 KB |
