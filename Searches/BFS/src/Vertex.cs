using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS
{
    // Summary:
    //          Represents a node for a Graph Data Structure
    // Variables:
    //          Value holds the vertex value that is type of T which is readonly.
    //          Distance represents the length from parent Vertex that can be arranged manually or in a search method.
    //          Neighbors represents neighbors of the vertex that is readonly.
    //          IsVisited is a control variable that controls wheter it is visited or not.
    //          NeighborCount represents the amount of neighbors.
    class Vertex<T>
    {
        public T Value { get; }
        public int Distance { get; set; }
        public List<Vertex<T>> Neighbors { get; }
        public bool IsVisited { get; set; }
        public int NeighborCount => Neighbors.Count;
        // Summary:
        //          Initializes the Vertex Class. 
        // Parameters:
        //          value is for filling the Value variable of Vertex Class.
        //          neighbors is default null that arrange Neighbors list.
        public Vertex(T value, IEnumerable<Vertex<T>> neighbors = null)
        {
            Value = value;
            Neighbors = neighbors?.ToList() ?? new List<Vertex<T>>();
            IsVisited = false;
        }
        // Summary:
        //          Adds vertex parameter into Neighbors list.
        // Parameters:
        //          vertex is a Vertex class.
        public void AddEdge(Vertex<T> vertex)
        {
            Neighbors.Add(vertex);
        }
        // Summary:
        //          Adds newNeighbors comes as an array into Neighbors list by using AddRange.
        // Parameters:
        //          vertex is a Vertex class.
        public void AddEdges(params Vertex<T>[] newNeighbors)
        {
            Neighbors.AddRange(newNeighbors);
        }
        // Summary:
        //          Adds newNeighbors comes as an IEnumerable list into Neighbors list by using AddRange.
        // Parameters:
        //          vertex is a Vertex class.
        public void AddEdges(IEnumerable<Vertex<T>> newNeighbors)
        {
            Neighbors.AddRange(newNeighbors);
        }
        // Summary:
        //          Removes parameter vertex from Neighbors.
        // Parameters:
        //          vertex is a Vertex class.
        public void RemoveEdge(Vertex<T> vertex)
        {
            Neighbors.Remove(vertex);
        }

        // Summary:
        //          Overrided ToString method returns neighbors of vertex in a layout.
        public override string ToString()
        {
            return Value+" : " +string.Join(" ", Neighbors.Select(n => n.Value));
        }

    }
}
