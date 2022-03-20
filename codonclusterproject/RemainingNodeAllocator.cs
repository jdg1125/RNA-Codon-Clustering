using System;
using System.Collections.Generic;

namespace RNACodonClustering
{
    public static class RemainingNodeAllocator
    {
        public static List<string>[] AllocateRemainingNodes(List<string>[] clusters, Graph graph)
        {
            if (graph.RemainingNodes.Count == 0)
                return clusters;

            graph.Shuffle(graph.RemainingNodes);

            double include = 0;
            double minimum = 0;
            double weight = 7;
            double[,] bestPlace = new double[graph.RemainingNodes.Count, clusters.Length + 1]; //row, col

            for (int i = 0; i < bestPlace.GetLength(0); i++)
                bestPlace[i, 0] = 1000;

            for (int i = 0; i < graph.RemainingNodes.Count; i++)
            {
                for (int j = 0; j < clusters.Length; j++)
                {
                    clusters[j].Add(graph.RemainingNodes[i]);
                    include = ObjectiveFunctionEvaluator.ComputeCut(clusters[j], graph) / clusters[j].Count;
                    if (clusters[j].Count > 3)
                        include += weight * (clusters[j].Count - 3);
                    clusters[j].Remove(graph.RemainingNodes[i]);

                    bestPlace[i, j + 1] = Math.Min(include, bestPlace[i, j]);
                }

                minimum = bestPlace[i, clusters.Length];

                for (int j = clusters.Length; j >= 0; j--)
                {
                    if (bestPlace[i, j] > minimum)
                    {
                        clusters[j].Add(graph.RemainingNodes[i]); //i corr to ith chosen node, j+1 corr to cluster j
                        break;
                    }
                }
            }

            graph.RemainingNodes.Clear();
            return clusters;
        }
    }
}
