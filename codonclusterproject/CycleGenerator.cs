using System;
using System.Collections.Generic;

namespace RNACodonClustering
{
    public static class CycleGenerator
    {
        public static List<string> MakeCycles(Graph graph)
        {
            List<string> cluster = new List<string>();

            if (graph.RemainingNodes.Count == 0)
                return cluster;

            string node = graph.RemainingNodes[0];
            cluster.Add(node);

            for (int i = 0; i < graph.adjList[node].Count; i++)
            {
                if (graph.RemainingNodes.Contains(graph.adjList[node][i]) == true)
                {
                    cluster.Add(graph.adjList[node][i]);

                    for (int j = i + 1; j < graph.adjList[node].Count; j++)
                    {
                        if (graph.RemainingNodes.Contains(graph.adjList[node][j]) == true)
                        {
                            cluster.Add(graph.adjList[node][j]);

                            if (IsCycle(cluster, graph))
                                break;
                            else
                                cluster.RemoveAt(cluster.Count - 1);
                        }
                    }

                    if (!IsCycle(cluster, graph))
                        cluster.RemoveAt(cluster.Count - 1);
                    else
                        break;
                }
            }

            foreach (string s in cluster)
                graph.RemainingNodes.Remove(s);

            return cluster;
        }

        public static bool IsCycle(List<string> cluster, Graph graph)
        {
            if (cluster.Count < 3)
                return false;

            for (int i = 0; i < cluster.Count; i++)
            {
                for (int j = i + 1; j < cluster.Count; j++)
                {
                    if (graph.adjList[cluster[i]].Contains(cluster[j]) == false)
                        return false;
                }
            }
            return true;
        }
    }
}
