using BenchmarkDotNet.Running;
using PerformanceMeasure;

var summary = BenchmarkRunner.Run<BenchmarkTest>();