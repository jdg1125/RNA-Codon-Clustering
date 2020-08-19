Codon Clustering Project (CSCI 4950 Project)

The canonical genetic code consists of 21 codon clusters, and a undirected graph can be constructed from all 48 possible RNA codons as nodes,
with edges connecting nodes that vary by only one letter (i.e. ACA and ACU would be connected, whereas ACA and UCG would not). 

The goal of this project is to suggest alternate clusterings (groupings) of codons of RNA that would be less susceptible to point-mutations.  
To find such groupings, the aim is to minimize the following objective function, 

f = c1/n1 + ... + ci/ni + ... + c21/n21, where ci denotes the number of edges outgoing from cluster i, and each ni is the number of nodes in cluster i.

The canonical arrangement of codons yields a value f=156. 

My proposal to find minimal groupings hinges on the observation that the minimum possible f-value, f=146, arises in instances in which the number
of 3-cliques is maximized.  Therefore, my solution passes through the graph and greedily tries to make as many 3-cliques as possible.  For each 
of the remaining nodes, a post-processing routine using dynamic programming selects the most optimal spot. 

I randomized the orientation of the graph, without changing its inherent structure, to allow for the output of multiple optimal cluster sets (f=146). 
I captured the output of several trials in a database. 
