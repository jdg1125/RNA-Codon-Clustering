using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace RNACodonClustering
{
    class Program
    {
        static void Main(string[] args)
        {
            int numExecutions;
            string userId, password;
            GetValuesFromCommandLineArgs(args, out numExecutions, out userId, out password);
            var dbConnector = new DatabaseConnector();
            var isDBConnected = dbConnector.TryOpenConnection(userId, password);
            var minimumObjFuncScore = double.PositiveInfinity;
            for (int i = 0; i < numExecutions; ++i)
            {
                var graph = new Graph();
                var clusters = new List<string>[21];
                for (int j = 0; j < 21; ++j)
                    clusters[j] = CycleGenerator.MakeCycles(graph);
                clusters = RemainingNodeAllocator.AllocateRemainingNodes(clusters, graph);
                var objectiveFuncResult = ObjectiveFunctionEvaluator.ComputeObjFunction(clusters, graph);
                minimumObjFuncScore = Math.Min(objectiveFuncResult, minimumObjFuncScore);
                if (isDBConnected)
                    dbConnector.SaveClusters(i, clusters, objectiveFuncResult);
            }
            if (isDBConnected)
                dbConnector.CloseConnection();
            Console.WriteLine($"The minimum objective function result over {numExecutions} executions was {minimumObjFuncScore}.");
            Console.ReadKey();
        }

        private static void GetValuesFromCommandLineArgs(string[] args, out int numExecutions, out string userId, out string password)
        {
            userId = "";
            password = "";
            numExecutions = 1;

            if (args.Length == 1 || args.Length == 3)
                int.TryParse(args[args.Length - 1], out numExecutions);
            if(args.Length == 2 || args.Length == 3)
            {
                userId = args[0];
                password = args[1];
            }
        }
    }
}


