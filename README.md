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
 |            Equals | LegacyJitX64 | LegacyJit |      X64 | 10.4266 ns | 0.0090 ns | 0.0338 ns |
 |       GetHashCode | LegacyJitX64 | LegacyJit |      X64 | 47.9099 ns | 0.0912 ns | 0.3533 ns |
 |      EqualsCached | LegacyJitX64 | LegacyJit |      X64 |  4.2168 ns | 0.0070 ns | 0.0260 ns |
 | GetHashCodeCached | LegacyJitX64 | LegacyJit |      X64 | 25.2044 ns | 0.0407 ns | 0.1576 ns |
 |            Equals | LegacyJitX86 | LegacyJit |      X86 |  9.6312 ns | 0.0323 ns | 0.1252 ns |
 |       GetHashCode | LegacyJitX86 | LegacyJit |      X86 | 46.9868 ns | 0.4833 ns | 2.1065 ns |
 |      EqualsCached | LegacyJitX86 | LegacyJit |      X86 |  3.9719 ns | 0.0330 ns | 0.1279 ns |
 | GetHashCodeCached | LegacyJitX86 | LegacyJit |      X86 | 20.4734 ns | 0.0514 ns | 0.1925 ns |
 |            Equals |    RyuJitX64 |    RyuJit |      X64 |  9.6321 ns | 0.0123 ns | 0.0476 ns |
 |       GetHashCode |    RyuJitX64 |    RyuJit |      X64 | 40.7101 ns | 0.0525 ns | 0.2035 ns |
 |      EqualsCached |    RyuJitX64 |    RyuJit |      X64 |  2.9862 ns | 0.0035 ns | 0.0130 ns |
 | GetHashCodeCached |    RyuJitX64 |    RyuJit |      X64 | 14.9397 ns | 0.1623 ns | 0.7073 ns |
