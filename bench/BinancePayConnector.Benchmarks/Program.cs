using BenchmarkDotNet.Running;
using BinancePayConnector.Benchmarks;

var summary = BenchmarkRunner.Run<BenchmarkTest>();