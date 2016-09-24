using System;
using System.IO;
using Dapper.BulkInserts.Benchmark;
using Newtonsoft.Json;

namespace Dapper.BulkInserts
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new DapperBenchmark().RunBenchmark(100000, 10);

            Console.Write(result.RenderResults());

            File.WriteAllText($"C:\\DapperBenchmarks\\Benchmark_{result.StartTime.Ticks}.json", JsonConvert.SerializeObject(result, Formatting.Indented));
            File.WriteAllText($"C:\\DapperBenchmarks\\Benchmark_{result.StartTime.Ticks}.txt", result.RenderResults());
            File.WriteAllText($"C:\\DapperBenchmarks\\Benchmark_{result.StartTime.Ticks}.csv", result.RenderResultCSV());

            Console.ReadLine();
        }
    }
}
