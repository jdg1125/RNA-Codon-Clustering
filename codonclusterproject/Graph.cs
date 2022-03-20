using System;
using System.Collections.Generic;

namespace RNACodonClustering
{
    public class Graph
    {
        public Dictionary<string, List<string>> adjList { get; set; }
        public List<string> RemainingNodes { get; set; }

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

            var allGroups = new string[][] { uuxGroup, uxuGroup, xuuGroup, aaxGroup, axaGroup, xaaGroup,ccxGroup, cxcGroup,
                xccGroup, ggxGroup, gxgGroup, xggGroup, uaxGroup, ucxGroup, ugxGroup, caxGroup, cgxGroup, cuxGroup, gaxGroup, gcxGroup, guxGroup,
                agxGroup, auxGroup, acxGroup, axgGroup, axcGroup, axuGroup, cxgGroup, cxaGroup, cxuGroup, gxaGroup, gxcGroup,gxuGroup, uxaGroup, uxcGroup,
                uxgGroup, xagGroup, xacGroup,xauGroup, xcgGroup, xcaGroup, xcuGroup, xgaGroup, xgcGroup, xguGroup, xugGroup, xucGroup, xuaGroup};

            foreach (string[] group in allGroups)
            {
                for (int i = 0; i < group.Length; i++)
                {
                    for (int j = 0; j < group.Length; j++)
                    {
                        if (i != j)
                            AddEdge(group[i], group[j]);
                    }
                }
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
    }
}
