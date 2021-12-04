``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1348 (20H2/October2020Update)
Intel Core i7-4790 CPU 3.60GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100
  [Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT


```
|              Method |     Mean |   Error |   StdDev | Ratio | RatioSD |   Gen 0 |  Gen 1 | Allocated |
|-------------------- |---------:|--------:|---------:|------:|--------:|--------:|-------:|----------:|
| ClassicDeserializer | 455.8 μs | 9.02 μs | 20.91 μs |  1.00 |    0.00 | 28.8086 | 9.2773 |    120 KB |
| GeneratedSerializer | 448.5 μs | 8.81 μs | 11.14 μs |  0.98 |    0.05 | 28.3203 | 8.7891 |    120 KB |
