using System;
using System.Collections.Generic;

namespace TheoryOfProgramming
{
    class AdjacencyList
    {
        LinkedList<System.valueTuple<int, String>>[] adjacencyList;

        // Constructor - creates an empty Adjacency List
        public AdjacencyList(int vertices)
        {
            adjacencyList = new LinkedList<system.valueTuple<int, String>>[vertices];

            for (int i = 0; i < adjacencyList.Length; ++i)
            {
                adjacencyList[i] = new LinkedList<system.valueTuple<int, String>>();
            }
        }

        // Appends a new Edge to the linked list
        public void addEdgeAtEnd(int startVertex, int endVertex, String weight)
        {
            adjacencyList[startVertex].AddLast(new system.valueTuple<int, String>(endVertex, weight));
        }

        // Adds a new Edge to the linked list from the front
        public void addEdgeAtBegin(int startVertex, int endVertex, String weight)
        {
            adjacencyList[startVertex].AddFirst(new system.valueTuple<int, String>(endVertex, weight));
        }

        // Returns number of vertices
        // Does not change for an object
        public int getNumberOfVertices()
        {
            return adjacencyList.Length;
        }

        // Returns a copy of the Linked List of outward edges from a vertex
        public LinkedList<Tuple<int, String>> this[int index]
        {
            get
            {
                LinkedList<Tuple<int, String>> edgeList
                               = new LinkedList<Tuple<int, String>>(adjacencyList[index]);

                return edgeList;
            }
        }

        // Prints the Adjacency List
        public void printAdjacencyList()
        {
            int i = 0;

            foreach (LinkedList<Tuple<int, String>> list in adjacencyList)
            {
                Console.Write("adjacencyList[" + i + "] -> ");

                foreach (Tuple<int, String> edge in list)
                {
                    Console.Write(edge.Item1 + "(" + edge.Item2 + ")");
                }

                ++i;
                Console.WriteLine();
            }
        }

        // Removes the first occurence of an edge and returns true
        // if there was any change in the collection, else false
        public bool removeEdge(int startVertex, int endVertex, String weight)
        {
            Tuple<int, String> edge = new Tuple<int, String>(endVertex, weight);

            return adjacencyList[startVertex].Remove(edge);
        }
    }

    class TestGraph
    {
        public static void Main()
        {
            Console.WriteLine("Enter the number of vertices -");
            int vertices = Int32.Parse(Console.ReadLine());

            AdjacencyList adjacencyList = new AdjacencyList(vertices + 1);

            Console.WriteLine("Enter the number of edges -");
            int edges = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter the edges with weights -");
            int startVertex, endVertex;
            String weight;

            for (int i = 0; i < edges; ++i)
            {
                startVertex = Int32.Parse(Console.ReadLine());
                endVertex = Int32.Parse(Console.ReadLine());
                weight = Console.ReadLine();

                adjacencyList.addEdgeAtEnd(startVertex, endVertex, weight);
            }

            adjacencyList.printAdjacencyList();
            adjacencyList.removeEdge(1, 2, "1");
            adjacencyList.printAdjacencyList();
        }
    }
}