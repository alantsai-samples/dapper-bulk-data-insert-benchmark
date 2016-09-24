using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.BulkInserts.Benchmark
{
    public class DapperBenchmarkRun
    {
        public TimeSpan InsertUsingForSingleInsertElapsed { get; set; }
        public TimeSpan InsertUsingForSingleInsertQueryElapsed { get; set; }

        public TimeSpan InsertUsingDapperCollectionElapsed { get; set; }
        public TimeSpan InsertUsingDataTableParameter { get; set; }
        public TimeSpan InsertUsingSqlBulk { get; internal set; }
    }

    public class DapperBenchmarkResult
    {
        public int NumberOfEntriesToInsertPerRun { get; set; }

        public int NumberOfRuns { get; set; }

        public DateTime StartTime { get; set; }

        public List<DapperBenchmarkRun> Results { get; set; }

        public DapperBenchmarkResult()
        {
            Results = new List<DapperBenchmarkRun>();
            StartTime = DateTime.UtcNow;
        }

        public DapperBenchmarkResult(int numberOfEntriesToInsertPerRun, int numberOfRuns) : this()
        {
            NumberOfEntriesToInsertPerRun = numberOfEntriesToInsertPerRun;
            NumberOfRuns = numberOfRuns;
        }

        public void Add(TimeSpan singleInsertTime, TimeSpan collectionInsertTime, TimeSpan dataTableInsertTime, 
            TimeSpan forloopQueryTime, TimeSpan sqlbulkTime)
        {
            Results.Add(new DapperBenchmarkRun
            {
                InsertUsingDapperCollectionElapsed = collectionInsertTime,
                InsertUsingForSingleInsertQueryElapsed = forloopQueryTime,
                InsertUsingForSingleInsertElapsed = singleInsertTime,
                InsertUsingDataTableParameter = dataTableInsertTime,
                InsertUsingSqlBulk = sqlbulkTime
            });
        }

        public string RenderResults()
        {
            var builder = new StringBuilder();
            builder.Append("======================================================== \n");
            builder.Append(
                $"Displaying the results of {NumberOfRuns} runs with {NumberOfEntriesToInsertPerRun} entries per run");

            builder.Append("\n");

            builder.Append("Single Insert \t || \t  Single Insert Query \t || \t Collection Insert \t || \t Data Table Insert \t || \t Sql bulk \n");
            builder.Append("==================================================================================================\n");

            foreach (var resultSet in Results)
            {
                builder.Append(
                    $"{resultSet.InsertUsingForSingleInsertElapsed} \t || \t {resultSet.InsertUsingForSingleInsertQueryElapsed} \t || \t {resultSet.InsertUsingDapperCollectionElapsed} \t || \t {resultSet.InsertUsingDataTableParameter} \t || \t {resultSet.InsertUsingSqlBulk} \n");
            }

            return builder.ToString();
        }

        public string RenderResultCSV()
        {
            var builder = new StringBuilder();

            builder.AppendLine("Single Insert, Single Insert Query, Collection, Tavble, Sql bulk");

             foreach (var resultSet in Results)
            {
                builder.AppendLine(
                    $"{resultSet.InsertUsingForSingleInsertElapsed.TotalSeconds}, {resultSet.InsertUsingForSingleInsertQueryElapsed.TotalSeconds}, {resultSet.InsertUsingDapperCollectionElapsed.TotalSeconds}, {resultSet.InsertUsingDataTableParameter.TotalSeconds}, {resultSet.InsertUsingSqlBulk.TotalSeconds}");
            }

            return builder.ToString();
        }
    }
}
