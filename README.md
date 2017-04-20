``` ini

BenchmarkDotNet=v0.10.3.0, OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-4770 CPU 3.40GHz, ProcessorCount=8
Frequency=3318387 Hz, Resolution=301.3512 ns, Timer=TSC
  [Host]       : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0
  LegacyJitX64 : Clr 4.0.30319.42000, 64bit LegacyJIT/clrjit-v4.6.1637.0;compatjit-v4.6.1637.0
  LegacyJitX86 : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.6.1637.0
  RyuJitX64    : Clr 4.0.30319.42000, 64bit RyuJIT-v4.6.1637.0

Runtime=Clr  

```
 |            Method |          Job |       Jit | Platform |       Mean |    StdErr |    StdDev |
 |------------------ |------------- |---------- |--------- |----------- |---------- |---------- |
 |            Equals | LegacyJitX64 | LegacyJit |      X64 | 13.3058 ns | 0.0159 ns | 0.0596 ns |
 |       GetHashCode | LegacyJitX64 | LegacyJit |      X64 | 53.3942 ns | 0.1326 ns | 0.5136 ns |
 |      EqualsCached | LegacyJitX64 | LegacyJit |      X64 |  9.6589 ns | 0.0504 ns | 0.1952 ns |
 | GetHashCodeCached | LegacyJitX64 | LegacyJit |      X64 | 26.9144 ns | 0.0585 ns | 0.2267 ns |
 |            Equals | LegacyJitX86 | LegacyJit |      X86 | 12.3289 ns | 0.0479 ns | 0.1856 ns |
 |       GetHashCode | LegacyJitX86 | LegacyJit |      X86 | 47.6645 ns | 0.1320 ns | 0.5112 ns |
 |      EqualsCached | LegacyJitX86 | LegacyJit |      X86 |  8.4311 ns | 0.1175 ns | 0.4843 ns |
 | GetHashCodeCached | LegacyJitX86 | LegacyJit |      X86 | 27.1333 ns | 0.1024 ns | 0.3966 ns |
 |            Equals |    RyuJitX64 |    RyuJit |      X64 | 11.5519 ns | 0.0509 ns | 0.1970 ns |
 |       GetHashCode |    RyuJitX64 |    RyuJit |      X64 | 46.0448 ns | 0.3826 ns | 1.4817 ns |
 |      EqualsCached |    RyuJitX64 |    RyuJit |      X64 |  5.4152 ns | 0.0092 ns | 0.0358 ns |
 | GetHashCodeCached |    RyuJitX64 |    RyuJit |      X64 | 16.4995 ns | 0.0323 ns | 0.1163 ns |
