using System;
using System.Collections.Generic;
using RNACodonClustering;

namespace RNACodonClustering
{
    public static class ObjectiveFunctionEvaluator
    {
        public static double ComputeObjFunction(List<string>[] clusters, Graph graph)
        {
            double sum = 0;
            for (int i = 0; i < clusters.Length; i++)
            {
                if (clusters[i] != null)
                    sum += ComputeCut(clusters[i], graph) / clusters[i].Count;
            }
            return sum;
        }

        public static double ComputeCut(List<string> cluster, Graph graph)
        {
            if (cluster.Count == 0)
                return 0;
            if (cluster.Count == 1)
                return 9;

            double result = 0;
            for (int i = 0; i < cluster.Count; i++) //go through every item in cluster
            {
                for (int j = 0; j < graph.adjList[cluster[i]].Count; j++)  //and look at its adjacent nodes
                {
                    if (cluster.Contains(graph.adjList[cluster[i]][j]) == false)  //and if they aren't in this cluster, incr result
                        result++;
                }
            }
            return result;
        }
    }
}
