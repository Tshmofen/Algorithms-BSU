using System.Collections.Generic;
using System.Linq;

namespace Graphs
{
    public class Graph
    {
        private List<List<int>> contiguity;

        public Graph(int size = 0)
        {
            this.contiguity = new List<List<int>>();
            for (int i = 0; i < size; i++)
            {
                this.contiguity.Add(new List<int>());
            }
        }

        public int Count => contiguity.Count;

        public bool IsEuler
        {
            get
            {
                for (int i = 0; i < Count; i++)
                {
                    if (contiguity[i].Count % 2 != 0)
                    {
                        return false;
                    }
                }
                return FindСomponents().Count == 1;
            }
        }

        public bool IsBipartite
        {
            get
            {
                if (Count == 0 || FindСomponents().Count != 1) { return false; }

                List<bool> verticesUsed = new List<bool>();
                for (int i = 0; i < Count; i++) { verticesUsed.Add(false); }
                List<int> firstColor = new List<int>(); 
                List<int> secondColor = new List<int>();

                DepthColorSearch(0, verticesUsed, firstColor, secondColor);
                foreach(int vertex in firstColor)
                {
                    if (secondColor.Contains(vertex))
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public List<List<int>> GetContiguityMatrix()
        {
            List<List<int>> contiguityCopy = new List<List<int>>(Count);
            for(int i = 0; i < Count; i++)
            {
                contiguityCopy.Add(new List<int>(contiguity[i]));
            }
            return contiguityCopy;
        }

        public void AddVertex()
        {
            contiguity.Add(new List<int>());
        }

        public void RemoveVertex(int index)
        {
            contiguity.RemoveAt(index);
            foreach(List<int> neighbors in contiguity)
            {
                neighbors.Remove(index);
            }
        }

        public void AddEdge(int vertexA, int vertexB)
        {
            if (vertexA != vertexB && !contiguity[vertexA].Contains(vertexB))
            {
                contiguity[vertexA].Add(vertexB);
                contiguity[vertexB].Add(vertexA);
            }
        }

        public void RemoveEdge(int vertexA, int vertexB)
        {
            contiguity[vertexA].Remove(vertexB);
            contiguity[vertexB].Remove(vertexA);
        }

        public List<int> FindEulerCycle(int initialVertex) {
            List<int> cycle = new List<int>();
            Graph tempCloneGraph = this.Clone();
            Stack<int> nextVertices = new Stack<int>();

            nextVertices.Push(initialVertex);
            if (!IsEuler) { return cycle; }
            while (nextVertices.Count != 0) 
            {
                int vertex = nextVertices.Peek();
                if (tempCloneGraph.contiguity[vertex].Count != 0)
                {
                    int nextNeighbor = tempCloneGraph.contiguity[vertex].First();
                    nextVertices.Push(nextNeighbor);
                    tempCloneGraph.RemoveEdge(vertex, nextNeighbor);
                }
                else 
                {
                    nextVertices.Pop();
                    cycle.Add(vertex);
                }
            }

            return cycle;
        }

        public Graph Clone()
        {
            Graph cloneGraph = new Graph();
            cloneGraph.contiguity = this.GetContiguityMatrix();
            return cloneGraph;
        }

        public void FindBipartiteParts(out List<int> firstPart, out List<int> secondPart)
        {
            List<bool> verticesUsed = new List<bool>();
            for (int i = 0; i < Count; i++) { verticesUsed.Add(false); }
            firstPart = new List<int>();
            secondPart = new List<int>();

            if (Count == 0 || FindСomponents().Count != 1) { return; }
            DepthColorSearch(0, verticesUsed, firstPart, secondPart);
            foreach (int vertex in firstPart)
            {
                if (secondPart.Contains(vertex))
                {
                    firstPart.Clear();
                    secondPart.Clear();
                    return;
                }
            }
        }

        public List<List<int>> FindСomponents()
        {
            List<List<int>> components = new List<List<int>>();
            List<bool> verticesUsed = new List<bool>();
            for(int i = 0; i < Count; i++)
            {
                verticesUsed.Add(false);
            }
            for (int i = 0; i < Count; i++)
            {
                if (!verticesUsed[i])
                {
                    List<int> verticesFound = new List<int>();
                    DepthSearch(i, verticesUsed, verticesFound);
                    components.Add(verticesFound);
                }
            }
            return components;
        }

        private void DepthSearch(int vertex, List<bool> verticesUsed, List<int> verticesFound)
        {
            verticesUsed[vertex] = true;
            verticesFound.Add(vertex);
            for (int i = 0; i < contiguity[vertex].Count; i++)
            {
                int nextVertex = contiguity[vertex][i];
                if (!verticesUsed[nextVertex]) 
                {
                    DepthSearch(nextVertex, verticesUsed, verticesFound); 
                }
            }
        }

        private void DepthColorSearch(int vertex, List<bool> verticesUsed
            , List<int> verticesFirstColor, List<int> verticesSecondColor)
        {
            verticesUsed[vertex] = true;
            if (verticesFirstColor.Count < verticesSecondColor.Count) 
            { 
                verticesFirstColor.Add(vertex); 
            }
            else
            {
                verticesSecondColor.Add(vertex);
            }
            
            for (int i = 0; i < contiguity[vertex].Count; i++)
            {
                int nextVertex = contiguity[vertex][i];
                if (!verticesUsed[nextVertex])
                {
                    DepthColorSearch(nextVertex, verticesUsed, verticesFirstColor, verticesSecondColor);
                }
            }
        }
    }
}
