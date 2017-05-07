``` ini

BenchmarkDotNet=v0.10.5, OS=Windows 10.0.14393
Processor=Intel Core m3-6Y30 CPU 0.90GHz, ProcessorCount=4
Frequency=1476563 Hz, Resolution=677.2484 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 64bit RyuJIT-v4.6.1637.0
  DefaultJob : Clr 4.0.30319.42000, 64bit RyuJIT-v4.6.1637.0


```
 |            Method |      Mean |     Error |    StdDev |    Median |
 |------------------ |----------:|----------:|----------:|----------:|
 |            Equals | 20.685 ns | 0.4669 ns | 0.7131 ns | 20.244 ns |
 |       GetHashCode | 79.314 ns | 1.6269 ns | 2.2807 ns | 79.630 ns |
 |      EqualsCached |  8.415 ns | 0.2338 ns | 0.5603 ns |  8.435 ns |
 | GetHashCodeCached | 30.641 ns | 0.6582 ns | 1.3592 ns | 31.058 ns |

``` ini

BenchmarkDotNet=v0.10.5, OS=Windows 10.0.14393
Processor=Intel Core m3-6Y30 CPU 0.90GHz, ProcessorCount=4
Frequency=1476563 Hz, Resolution=677.2484 ns, Timer=TSC
dotnet cli version=1.0.3
  [Host]     : .NET Core 4.6.25009.03, 64bit RyuJIT
  DefaultJob : .NET Core 4.6.25009.03, 64bit RyuJIT


```
 |            Method |     Mean |     Error |    StdDev |   Median |
 |------------------ |---------:|----------:|----------:|---------:|
 |            Equals | 14.09 ns | 0.2348 ns | 0.1553 ns | 14.06 ns |
 |       GetHashCode | 53.14 ns | 0.8117 ns | 0.7196 ns | 53.14 ns |
 |      EqualsCached | 13.69 ns | 0.3298 ns | 0.8455 ns | 13.40 ns |
 | GetHashCodeCached | 37.12 ns | 0.6052 ns | 0.5053 ns | 36.97 ns |
