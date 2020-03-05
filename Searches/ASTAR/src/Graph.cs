using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS
{
    // Summary:
    //      Represents a Graph Data Structure
    // Variables:
    //      Nodes:stores Node by using list structure.
    //      Size:represents Node list lenght.
    class Graph<T>
    {
        public List<Node<T>> Nodes { get; }
        public int Size => Nodes.Count;

        // Summary:
        //      Initializes the Graph Class. 
        // Parameters:
        //      initialNodes:a Node IEnumerable list for initializing Nodes that is default null.
        public Graph(IEnumerable<Node<T>> initialNodes = null)
        {
            Nodes = initialNodes?.ToList() ?? new List<Node<T>>();
        }

        // Summary:
        //      Adds node parameters into Node list and make a path from first to second.
        // Parameters:
        //      first:a Node that is source in the path hierarchy.
        //      second:Node that is destination in the path hierarchy.
        //      Distance:length between first and second.
        public void Add(Node<T> first, Node<T> second,int Distance)
        {
            AddToList(first);
            AddToList(second);
            AddNeighbor(first, second,Distance);
        }
        // Summary:
        //      Adds node parameters into Node list and make a path between each other.
        // Parameters:
        //      first:a Node that is source in the path hierarchy.
        //      second:Node that is destination in the path hierarchy.
        //      Distance:length between first and second.
        public void AddPair(Node<T> first, Node<T> second,int Distance)
        {
            AddToList(first);
            AddToList(second);
            AddNeighbors(first, second,Distance);
        }

        private void AddToList(Node<T> vertex)
        {
            if (!Nodes.Contains(vertex))
            {
                Nodes.Add(vertex);
            }
        }

        private void AddNeighbor(Node<T> first, Node<T> second,int Distance)
        {
            Neighbor<T> neighbor = new Neighbor<T>(second, Distance);
            if (!first.Neighbors.Contains(neighbor))
            {
                first.AddEdge(neighbor);
            }
        }

        private void AddNeighbors(Node<T> first, Node<T> second,int Distance)
        {
            AddNeighbor(first, second,Distance);
            AddNeighbor(second, first,Distance);
        }

        // Summary:
        //      Makes all of the Node's IsVisited variable false. 
        public void UnvisitAll()
        {
            foreach (var temp in Nodes)
            {
                temp.IsVisited = false;
            }
        }


    }
}
