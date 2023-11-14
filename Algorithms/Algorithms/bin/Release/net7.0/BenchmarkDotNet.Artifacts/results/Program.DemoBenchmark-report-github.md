```

BenchmarkDotNet v0.13.10, Windows 11 (10.0.22621.2428/22H2/2022Update/SunValley2)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 7.0.302
  [Host]     : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2


```
| Method       | Mean      | Error     | StdDev    | Median    |
|------------- |----------:|----------:|----------:|----------:|
| TestAdd      | 0.0349 ns | 0.0217 ns | 0.0233 ns | 0.0382 ns |
| TestMinus    | 0.0053 ns | 0.0071 ns | 0.0066 ns | 0.0013 ns |
| TestMultiply | 0.0146 ns | 0.0161 ns | 0.0220 ns | 0.0012 ns |
| TestDivide   | 0.0000 ns | 0.0000 ns | 0.0000 ns | 0.0000 ns |
