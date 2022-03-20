RNA Codon Clustering (CSCI 4950 Project)

The 21 amino acids forming the basis of all life on Earth can each be expressed as a cluster of RNA codons. 
An undirected graph can be constructed from all 48 possible RNA codons as nodes, with edges connecting nodes that vary by only one letter. 
For instance, ACA and ACU would be connected; ACA and UCG would not. 

The goal of this project is to discover alternative, albeit notional, clusterings that would be less susceptible to point-mutations.  
Cluster arrangements that would prove least likely to incur such mutations minimize the value of f given by the following objective function:

f = c1/n1 + ... + ci/ni + ... + c21/n21

Above, ci denotes the number of edges outgoing from cluster i, and ni is the number of nodes belonging to cluster i.

Evaluating this function for the canonical arrangement of codon clusters yields the value f = 156. 

To minimize f, my solution stems from the observation that the absolute minimum of f, f = 146, arises in arrangements in which the number of 3-cliques is maximized.  

The algorithm I propose here operates in two stages:
The first is to greedily create as many 3-cliques as possible. 
The second is to use dynamic programming to select the most optimal spot for the nodes left over after step one.
I exploit randomization by varying the source node of the graph to find multiple optimal cluster sets. 

-----------------------------------------------------------------------------------------------------------------------------------------------------------

The project integrates with a local MySQL instance to record the outcome of each execution. 
To use the project with your own MySQL instance, create a database named Results_MakeCluster_Algorithm.
In this database, create a table named Finished_Clusters, with the structure: 

Index VARCHAR(15) | Clusters (VARCHAR(300) | FunctionValue VARCHAR(20)

Running the app from the CLI, you have the following argument list options: 
1. No arguments. This will default to a single execution of the algorithm and no database configuration.
2. A single integer value denoting the number of times to execute the algorithm. 
    i.e.      % codonclusterproject.exe 20
3. A user id and password to use to try to connect to your MySQL instance. 
    i.e.      % codonclusterproject.exe userId password
4. A user id and password followed by an integer value.
    i.e.      % codonclusterproject.exe userId password 20
    
