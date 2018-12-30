using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using OrmBenchmark.Core;

namespace OrmBenchmark.ConsoleUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connStr = ConfigurationManager.ConnectionStrings["sqlServerLocal"].ConnectionString;
            bool warmUp = false;

            var defaultColor = Console.ForegroundColor;

            var benchmarker = new Benchmarker(connStr, 500);

            benchmarker.RegisterOrmExecuter(new Ado.PureAdoExecuter());
            benchmarker.RegisterOrmExecuter(new OrmBenchmartk.WeihanLi.Common.WeihanLiCommonExecuter());
            benchmarker.RegisterOrmExecuter(new Dapper.DapperExecuter());
            benchmarker.RegisterOrmExecuter(new Dapper.DapperBufferedExecuter());
            benchmarker.RegisterOrmExecuter(new Dapper.DapperFirstOrDefaultExecuter());
            benchmarker.RegisterOrmExecuter(new Dapper.DapperContribExecuter());
            benchmarker.RegisterOrmExecuter(new EntityFramework.EntityFrameworkExecuter());
            benchmarker.RegisterOrmExecuter(new EntityFramework.EntityFrameworkNoTrackingExecuter());
            benchmarker.RegisterOrmExecuter(new OrmLite.OrmLiteExecuter());

            Console.Write("\nDo you like to have a warm-up stage(y/[n])?");
            var str = Console.ReadLine();
            if (str.Trim().ToLower() == "y" || str.Trim().ToLower() == "yes")
                warmUp = true;

            Console.WriteLine(".NET: " + Environment.Version);
            Console.WriteLine("Connection string: {0}", connStr);
            Console.Write("\nRunning...");
            benchmarker.Run(warmUp);
            Console.WriteLine("Finished.");

            Console.ForegroundColor = ConsoleColor.Red;

            if (warmUp)
            {
                Console.WriteLine("\nPerformance of Warm-up:");
                ShowResults(benchmarker.resultsWarmUp, false, false);
            }

            Console.WriteLine("\nPerformance of select and map a row to a POCO object over 500 iterations:");
            ShowResults(benchmarker.results, true);

            Console.WriteLine("\nPerformance of mapping 5000 rows to POCO objects in one iteration:");
            ShowResults(benchmarker.resultsForAllItems);

            Console.ForegroundColor = defaultColor;

            Console.ReadLine();
        }

        private static void ShowResults(List<BenchmarkResult> results, bool showFirstRun = false, bool ignoreZeroTimes = true)
        {
            var defaultColor = Console.ForegroundColor;

            int i = 0;
            var list = results.OrderBy(o => o.ExecTime);
            if (ignoreZeroTimes)
                list = results.FindAll(o => o.ExecTime > 0).OrderBy(o => o.ExecTime);

            foreach (var result in list)
            {
                Console.ForegroundColor = i < 3 ? ConsoleColor.Green : ConsoleColor.Gray;

                if (showFirstRun)
                {
                    Console.WriteLine(
                        $"{++i,2}-{result.Name,-40} {result.ExecTime,5} ms (First run: {result.FirstItemExecTime,3} ms)");
                }
                else
                {
                    Console.WriteLine($"{++i,2}-{result.Name,-40} {result.ExecTime,5} ms");
                }
            }

            Console.ForegroundColor = defaultColor;
        }
    }
}
