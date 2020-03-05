using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS
{
    // Summary:
    //          Represents a Graph Data Structure
    // Variables:
    //          Vertices stores Vertex by using list structure.
    //          Size represents Vertex list lenght.
    class Graph<T>
    {
        public List<Vertex<T>> Vertices { get; }
        public int Size => Vertices.Count;

        // Summary:
        //          Initializes the Graph Class. 
        // Parameters:
        //          initialNodes is a Vertex IEnumerable list for initializing Vertices that is default null.
        public Graph(IEnumerable<Vertex<T>> initialNodes = null)
        {
            Vertices = initialNodes?.ToList() ?? new List<Vertex<T>>();
        }

        // Summary:
        //          Adds vertex parameters into Vertex list and make a path from first to second.
        // Parameters:
        //          first is a Vertex that is source in the path hierarchy.
        //          second is a Vertex that is destination in the path hierarchy.
        public void Add(Vertex<T> first,Vertex<T> second)
        {
            AddToList(first);
            AddToList(second);
            AddNeighbor(first, second);
        }
        // Summary:
        //          Adds vertex parameters into Vertex list and make a path between each other.
        // Parameters:
        //          first is a Vertex.
        //          second is a Vertex.
        public void AddPair(Vertex<T> first,Vertex<T> second)
        {
            AddToList(first);
            AddToList(second);
            AddNeighbors(first, second);
        }

        private void AddToList(Vertex<T> vertex)
        {
            if (!Vertices.Contains(vertex))
            {
                Vertices.Add(vertex);
            }
        }

        private void AddNeighbor(Vertex<T> first,Vertex<T> second)
        {
            if (!first.Neighbors.Contains(second))
            {
                first.AddEdge(second);
            }
        }

        private void AddNeighbors(Vertex<T> first, Vertex<T> second)
        {
            AddNeighbor(first, second);
            AddNeighbor(second, first);
        }

        // Summary:
        //          Makes all of the Vertice's IsVisited variable false. 
        public void UnvisitAll()
        {
            foreach(var Vertex in Vertices)
            {
                Vertex.IsVisited = false;
            }
        }


    }
}
