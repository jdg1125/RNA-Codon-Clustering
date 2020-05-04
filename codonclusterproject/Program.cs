using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using MySql.Data.MySqlClient;


namespace codonclusterproject
{
    public class Graph
    {
        public Dictionary<string, List<string>> adjList { get; set; }
        public List<string> RemainingNodes { get; set; }

        public override string ToString()
        {
            foreach (var key in adjList.Keys)
            {
                Console.Write(key + ":  ");

                if (adjList[key].Count != 0)
                {
                    for (int i = 0; i < adjList[key].Count; i++)
                        Console.Write(adjList[key][i] + ", ");
                }
                Console.WriteLine();

            }
            return null;
        }
        public void AddEdge(string from, string to)
        {
            if (!adjList.ContainsKey(from))
                AddNode(from);

            if (!adjList.ContainsKey(to))
                AddNode(to);

            if (adjList[from].Contains(to) == false)
                adjList[from].Add(to);

        }
        public void AddNode(string arg)
        {
            if (adjList.ContainsKey(arg))
                return;
            else
            {
                adjList.Add(arg, null);
                adjList[arg] = new List<string>();
            }
        }

        public void Populate()
        {
            string[] uuxGroup = { "UUU", "UUA", "UUC", "UUG" };
            string[] uxuGroup = { "UUU", "UAU", "UCU", "UGU" };
            string[] xuuGroup = { "UUU", "AUU", "CUU", "GUU" };
            string[] aaxGroup = { "AAA", "AAU", "AAC", "AAG" };
            string[] axaGroup = { "AAA", "AUA", "ACA", "AGA" };
            string[] xaaGroup = { "AAA", "UAA", "CAA", "GAA" };
            string[] ccxGroup = { "CCC", "CCU", "CCA", "CCG" };
            string[] cxcGroup = { "CCC", "CUC", "CAC", "CGC" };
            string[] xccGroup = { "CCC", "UCC", "ACC", "GCC" };
            string[] ggxGroup = { "GGG", "GGU", "GGC", "GGA" };
            string[] gxgGroup = { "GGG", "GUG", "GCG", "GAG" };
            string[] xggGroup = { "GGG", "UGG", "CGG", "AGG" };

            string[] uaxGroup = { "UAU", "UAG", "UAC", "UAA" };
            string[] ucxGroup = { "UCU", "UCA", "UCG", "UCC" };
            string[] ugxGroup = { "UGU", "UGA", "UGG", "UGC" };

            string[] caxGroup = { "CAC", "CAA", "CAG", "CAU" };
            string[] cgxGroup = { "CGC", "CGA", "CGG", "CGU" };
            string[] cuxGroup = { "CUC", "CUA", "CUG", "CUU" };

            string[] gaxGroup = { "GAC", "GAA", "GAG", "GAU" };
            string[] gcxGroup = { "GCC", "GCA", "GCG", "GCU" };
            string[] guxGroup = { "GUC", "GUA", "GUG", "GUU" };

            string[] agxGroup = { "AGC", "AGA", "AGG", "AGU" };
            string[] auxGroup = { "AUC", "AUA", "AUG", "AUU" };
            string[] acxGroup = { "ACC", "ACA", "ACG", "ACU" };

            string[] axgGroup = { "AAG", "AUG", "ACG", "AGG" };
            string[] axcGroup = { "AAC", "AUC", "ACC", "AGC" };
            string[] axuGroup = { "AAU", "ACU", "AGU", "AUU" };

            string[] cxgGroup = { "CAG", "CUG", "CCG", "CGG" };
            string[] cxaGroup = { "CAA", "CUA", "CCA", "CGA" };
            string[] cxuGroup = { "CAU", "CCU", "CGU", "CUU" };

            string[] gxaGroup = { "GAA", "GUA", "GGA", "GCA" };
            string[] gxcGroup = { "GAC", "GUC", "GCC", "GGC" };
            string[] gxuGroup = { "GAU", "GCU", "GGU", "GUU" };

            string[] uxaGroup = { "UAA", "UUA", "UGA", "UCA" };
            string[] uxcGroup = { "UAC", "UUC", "UCC", "UGC" };
            string[] uxgGroup = { "UAG", "UCG", "UGG", "UUG" };

            string[] xagGroup = { "AAG", "CAG", "UAG", "GAG" };
            string[] xacGroup = { "AAC", "CAC", "UAC", "GAC" };
            string[] xauGroup = { "AAU", "CAU", "UAU", "GAU" };

            string[] xcgGroup = { "ACG", "CCG", "UCG", "GCG" };
            string[] xcaGroup = { "ACA", "CCA", "UCA", "GCA" };
            string[] xcuGroup = { "ACU", "CCU", "UCU", "GCU" };

            string[] xgaGroup = { "AGA", "CGA", "UGA", "GGA" };
            string[] xgcGroup = { "AGC", "CGC", "UGC", "GGC" };
            string[] xguGroup = { "AGU", "CGU", "UGU", "GGU" };

            string[] xugGroup = { "AUG", "CUG", "UUG", "GUG" };
            string[] xucGroup = { "AUC", "CUC", "UUC", "GUC" };
            string[] xuaGroup = { "AUA", "CUA", "UUA", "GUA" };

            foreach (string[] group in new string[][] { uuxGroup, uxuGroup, xuuGroup, aaxGroup, axaGroup, xaaGroup,ccxGroup, cxcGroup,
                xccGroup, ggxGroup, gxgGroup, xggGroup, uaxGroup, ucxGroup, ugxGroup, caxGroup, cgxGroup, cuxGroup, gaxGroup, gcxGroup, guxGroup,
                agxGroup, auxGroup, acxGroup, axgGroup, axcGroup, axuGroup, cxgGroup, cxaGroup, cxuGroup, gxaGroup, gxcGroup,gxuGroup, uxaGroup, uxcGroup,
                uxgGroup, xagGroup, xacGroup,xauGroup, xcgGroup, xcaGroup, xcuGroup, xgaGroup, xgcGroup, xguGroup, xugGroup, xucGroup, xuaGroup})
            {
                for (int i = 0; i < group.Length; i++)
                    for (int j = 0; j < group.Length; j++)
                        if (i != j)
                            AddEdge(group[i], group[j]);

            }
        }

        public void Shuffle(List<string> arg)
        {
            Random aRan = new Random();
            int j = 0;
            string tmp;
            int len = arg.Count;

            for (int i = 0; i < len; i++)
            {
                j = aRan.Next(0, len);
                tmp = arg[i];
                arg[i] = arg[j];
                arg[j] = tmp;
            }

        }
        public Graph()
        {
            adjList = new Dictionary<string, List<string>>();
            Populate();

            foreach (var key in adjList.Keys)
                Shuffle(adjList[key]);

            RemainingNodes = new List<string>();

            foreach (var key in adjList.Keys)
                RemainingNodes.Add(key);

            Shuffle(RemainingNodes);

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int rowsAffected = 0;

            StringBuilder insertCommand = new StringBuilder();

            MySqlConnectionStringBuilder connBuilder = new MySqlConnectionStringBuilder();

            connBuilder.Add("Database", "Results_MakeCluster_Algorithm");
            connBuilder.Add("Data Source", "localhost");
            connBuilder.Add("User Id", "root");
            connBuilder.Add("Password", "***");  //change this line before running

            MySqlConnection connection = new MySqlConnection(connBuilder.ConnectionString);
            MySqlCommand cmd = connection.CreateCommand();

            connection.Open();

            for (int number = 0; number < 1000; number++)
            {
                Graph graph = new Graph();
                List<string>[] clusters = new List<string>[21];

                for (int i = 0; i < 21; i++)
                    clusters[i] = MakeCycles(graph);

                clusters = PostProcess(clusters, graph);

                insertCommand.Append("INSERT INTO Finished_Clusters VALUES (");
                insertCommand.Append(number.ToString() + ", ");

                for (int j = 0; j < clusters.Length; j++)
                    insertCommand.Append(ListToString(clusters[j]) + ",");

                insertCommand.Append(ComputeObjFunction(clusters, graph).ToString() + ");");

                cmd.CommandText = insertCommand.ToString();

                rowsAffected += cmd.ExecuteNonQuery();

                insertCommand.Clear();

            }

            connection.Close();

            Console.WriteLine(rowsAffected);

            Console.ReadKey();
        }

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

        public static List<string>[] PostProcess(List<string>[] clusters, Graph graph)
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
                    include = ComputeCut(clusters[j], graph) / clusters[j].Count;
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
        
        public static double ComputeCut(List<string> cluster, Graph graph)
        {

            double result = 0;

            if (cluster.Count == 0)
                return 0;

            if (cluster.Count == 1)
                return 9;

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


        public static string ListToString(List<string> cluster)
        {
            StringBuilder concat = new StringBuilder();

            concat.Append("'");
            foreach (string s in cluster)
            {
                concat.Append(s + ":");
            }
            concat.Append("'");

            return concat.ToString();
        }

    }
}

