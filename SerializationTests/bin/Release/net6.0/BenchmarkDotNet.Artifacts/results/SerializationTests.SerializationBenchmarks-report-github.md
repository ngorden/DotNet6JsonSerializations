``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19042.1348 (20H2/October2020Update)
Intel Core i7-4790 CPU 3.60GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.100
  [Host]     : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT


```
|                       Method | Categories |     Mean |   Error |  StdDev | Ratio |   Gen 0 |   Gen 1 |   Gen 2 | Allocated |
|----------------------------- |----------- |---------:|--------:|--------:|------:|--------:|--------:|--------:|----------:|
|            ClassicSerializer |     Stream | 249.7 μs | 2.65 μs | 2.48 μs |  1.00 | 37.1094 | 11.7188 |       - |    155 KB |
|          GeneratedSerializer |     Stream | 150.0 μs | 0.98 μs | 0.92 μs |  0.60 | 37.3535 |  0.4883 |       - |    154 KB |
|                              |            |          |         |         |       |         |         |         |           |
|   ClassicSerializer_AsString |     String | 411.6 μs | 6.53 μs | 5.10 μs |  1.00 | 53.7109 | 26.8555 | 26.8555 |    282 KB |
| GeneratedSerializer_AsString |     String | 369.2 μs | 3.23 μs | 2.52 μs |  0.90 | 53.7109 | 26.8555 | 26.8555 |    281 KB |
