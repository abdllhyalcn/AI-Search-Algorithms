using System.Collections.Generic;
using System.Linq;

namespace Searches
{
    //Summary:
    //      Stores the neighbor and distance to the neighbor.
    struct Neighbor<T>
    {
        public Node<T> neighbor { get; }
        public int DistanceToNeighbor { get; }
        public Neighbor(Node<T> neighbor,int Distance)
        {
            this.neighbor=neighbor;
            this.DistanceToNeighbor=Distance;
        }
    }
    // Summary:
    //      Represents a node for a Graph Data Structure
    // Variables:
    //      Name:Represents the Node name given int the constructor.
    //      Depth:Stores the depth attribute of the node.
    //      Neighbors:Includes Neighbor struct.
    //      IsVisited:Control variable that is used in searches.
    //      HanG:Stores the heuristic and actual cost.
    //      F:is the sum of heuristic and actual cost.
    class Node<T>
    {
        public string Name { get; }
        public int Depth;
        public List<Neighbor<T>> Neighbors { get; }
        public bool IsVisited { get; set; } = false;

        public int[,] HandG=new int[1,2];
        public int F => HandG[0,0]+HandG[0,1];

        // Summary:
        //      Initializes the Node Class. 
        // Parameters:
        //      name:The node name.
        //      h:Heuristic value.
        //      g:Actual cost value.
        //      neighbors:The initialized neighbor list of the node.
        public Node(string name,int h=0,int g=0, IEnumerable<Neighbor<T>> neighbors = null)
        {
            Name = name;
            Neighbors = neighbors?.ToList() ?? new List<Neighbor<T>>();
            this.HandG =new int[,]{ { h, g } };
        }
        // Summary:
        //      Initializes the Node Class. 
        // Parameters:
        //      name:The node name.
        //      neighbors:The initialized neighbor list of the node.
        public Node(string name, IEnumerable<Neighbor<T>> neighbors = null)
        {
            Name = name;
            Neighbors = neighbors?.ToList() ?? new List<Neighbor<T>>();
        }
        // Summary:
        //       Adds neighbor into Neighbors list.
        // Parameters:
        //       neighbor: is a Neighbor struct.
        public void AddEdge(Neighbor<T> neighbor)
        {
            Neighbors.Add(neighbor);
        }
        // Summary:
        //      Adds newNeighbors comes as an array into Neighbors list by using AddRange.
        // Parameters:
        //      newNeighbors:is a Neighbor Struct array.
        public void AddEdges(params Neighbor<T>[] newNeighbors)
        {
            Neighbors.AddRange(newNeighbors);
        }
        // Summary:
        //      Adds newNeighbors comes as an IEnumerable list into Neighbors list by using AddRange.
        // Parameters:
        //      wNeighbors:is a Neighbor Struct list.
        public void AddEdges(IEnumerable<Neighbor<T>> newNeighbors)
        {
            Neighbors.AddRange(newNeighbors);
        }
        // Summary:
        //      Removes parameter neighbor from Neighbors.
        // Parameters:
        //      neighbor:is a Neighbor struct.
        public void RemoveEdge(Neighbor<T> neighbor)
        {
            Neighbors.Remove(neighbor);
        }

        // Summary:
        //          Overrided ToString method returns neighbors of neighbor in a layout."this name(F) : neighbor's names of this"
        public override string ToString()
        {
            return Name+"("+F+")"+" : " +string.Join(" ", Neighbors.Select(n => n.neighbor.Name));
        }

    }
}
