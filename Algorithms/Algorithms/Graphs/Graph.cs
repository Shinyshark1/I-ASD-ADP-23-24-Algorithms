using System.Text;

namespace Algorithms.Graphs
{
    public class Graph
    {
        private Dictionary<string, Vertex> _vertexDictionary = new();

        #region Algorithms

        public Dictionary<string, Vertex> GetShortestUnweightedPath(string sourceVertexName)
        {
            if (_vertexDictionary.ContainsKey(sourceVertexName) == false)
            {
                throw new InvalidOperationException($"Vertex '{sourceVertexName}' does not exist in the Graph.");
            }

            ResetVertexDictionary();

            var startingVertex = _vertexDictionary[sourceVertexName];
            startingVertex.Distance = 0;

            Queue<Vertex> queue = new Queue<Vertex>();
            queue.Enqueue(startingVertex);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                foreach (var edge in vertex.Edges)
                {
                    var destinationVertex = edge.SecondVertex;
                    if (destinationVertex.Distance == double.PositiveInfinity)
                    {
                        destinationVertex.Distance = vertex.Distance + 1;
                        destinationVertex.PreviousVertex = vertex;
                        queue.Enqueue(destinationVertex);
                    }
                }
            }

            return _vertexDictionary;
        }

        public Dictionary<string, Vertex> GetShortestWeightedPath(string sourceVertexName)
        {
            if (_vertexDictionary.ContainsKey(sourceVertexName) == false)
            {
                throw new InvalidOperationException($"Vertex '{sourceVertexName}' does not exist in the Graph.");
            }

            if (_vertexDictionary.Values.SelectMany(x => x.Edges).Any(e => e.Cost < 0))
            {
                throw new Exception("The Dijkstra algorithm does not support negative costs between nodes.");
            }

            ResetVertexDictionary();

            var startingVertex = _vertexDictionary[sourceVertexName];
            startingVertex.Distance = 0;

            var visitedVertices = new List<string>();

            var priorityQueue = new PriorityQueue<Vertex, double>();
            priorityQueue.Enqueue(startingVertex, 0);
            while (priorityQueue.Count > 0)
            {
                var currentVertex = priorityQueue.Dequeue();
                foreach (var edge in currentVertex.Edges.OrderBy(x => x.Cost))
                {
                    if (visitedVertices.Contains(edge.SecondVertex.Name))
                    {
                        continue;
                    }

                    var comparisonVertex = edge.SecondVertex;
                    var totalDistance = currentVertex.Distance + edge.Cost;
                    if (totalDistance < comparisonVertex.Distance)
                    {
                        comparisonVertex.Distance = totalDistance;
                        comparisonVertex.PreviousVertex = currentVertex;
                    }
                }

                visitedVertices.Add(currentVertex.Name);

                var nextItem = _vertexDictionary.Values
                    .Where(x => visitedVertices.Contains(x.Name) == false)
                    .OrderBy(x => x.Distance)
                    .FirstOrDefault();

                if (nextItem != null)
                {
                    priorityQueue.Enqueue(nextItem, nextItem.Distance);
                }
            }

            return _vertexDictionary;
        }

        #endregion

        #region CRUD Action 

        public Vertex? GetVertex(string vertexName)
        {
            _vertexDictionary.TryGetValue(vertexName, out Vertex? vertex);
            return vertex;
        }

        public void AddVertex(string vertexName)
        {
            AddVertex(new Vertex(vertexName));
        }

        public void AddVertex(Vertex vertex)
        {
            if (_vertexDictionary.ContainsKey(vertex.Name))
            {
                throw new InvalidOperationException($"Vertex '{vertex.Name}' already exists in the Graph.");
            }

            _vertexDictionary.Add(vertex.Name, vertex);
        }

        public void RemoveVertex(string vertexName)
        {
            RemoveVertex(new Vertex(vertexName));
        }

        public void RemoveVertex(Vertex vertex)
        {
            if (_vertexDictionary.ContainsKey(vertex.Name) == false)
            {
                throw new InvalidOperationException($"Vertex '{vertex.Name}' does not exist in the Graph.");
            }

            foreach (var keyValuePair in _vertexDictionary)
            {
                _ = RemoveEdge(vertex.Name, keyValuePair.Value.Name);
            }

            _vertexDictionary.Remove(vertex.Name);
        }

        public void AddEdge(Vertex firstVertex, Vertex secondVertex, double cost)
        {
            var existingEdge = firstVertex.Edges.FirstOrDefault(x => x.SecondVertex.Equals(secondVertex));
            if (existingEdge != null)
            {
                throw new InvalidOperationException($"A link between vertex '{firstVertex.Name}' and and vertex '{secondVertex.Name} already exists.'");
            }

            firstVertex.Edges.AddLast(new Edge(secondVertex, cost));
        }

        public bool RemoveEdge(string firstVertexName, string secondVertexName)
        {
            var firstVertex = _vertexDictionary[firstVertexName];
            var secondVertex = _vertexDictionary[secondVertexName];

            var linkedVertex = firstVertex.Edges.FirstOrDefault(x => x.SecondVertex.Equals(secondVertex));
            return firstVertex.Edges.Remove(linkedVertex);
        }

        #endregion

        #region Initiating

        public void InitiateLineList(int[,] lineList)
        {
            for (int i = 0; i < lineList.GetLength(0); i++)
            {
                var key = $"{lineList[i, 0]}";
                Vertex vertex = CreateAndRetrieveKey(key);

                var connectedVertexKey = $"{lineList[i, 1]}";
                Vertex connectedVertex = CreateAndRetrieveKey(connectedVertexKey);

                var cost = 0;
                if (lineList.GetLength(1) == 3)
                {
                    cost = lineList[i, 2];
                }

                vertex.AddEdge(connectedVertex, cost);
            }
        }

        public void InitiateConnectionList(int[][] connectionList)
        {
            for (int i = 0; i < connectionList.Length; i++)
            {
                var key = $"{i}";
                Vertex vertex = CreateAndRetrieveKey(key);
                for (int j = 0; j < connectionList[i].Length; j++)
                {
                    var connectedVertexKey = $"{connectionList[i][j]}";
                    Vertex connectedVertex = CreateAndRetrieveKey(connectedVertexKey);
                    vertex.AddEdge(connectedVertex, 0);
                }
            }
        }

        public void InitiateConnectionList(int[][][] connectionList)
        {
            for (int i = 0; i < connectionList.Length; i++)
            {
                var key = $"{i}";
                Vertex vertex = CreateAndRetrieveKey(key);
                for (int j = 0; j < connectionList[i].Length; j++)
                {
                    var connectedVertexKey = $"{connectionList[i][j][0]}";
                    Vertex connectedVertex = CreateAndRetrieveKey(connectedVertexKey);
                    vertex.AddEdge(connectedVertex, connectionList[i][j][1]);
                }
            }
        }

        public void InitiateMatrixList(int[][] matrixList)
        {
            for (int i = 0; i < matrixList.Length; i++)
            {
                var key = $"{i}";
                Vertex vertex = CreateAndRetrieveKey(key);
                for (int j = 0; j < matrixList[i].Length; j++)
                {
                    var cost = matrixList[i][j];
                    if (cost == 0 && i != j)
                    {
                        continue;
                    }

                    var connectedVertexKey = $"{j}";
                    Vertex connectedVertex = CreateAndRetrieveKey(connectedVertexKey);
                    vertex.AddEdge(connectedVertex, matrixList[i][j]);
                }
            }
        }

        private Vertex CreateAndRetrieveKey(string key)
        {
            if (_vertexDictionary.ContainsKey(key) == false)
            {
                _vertexDictionary.Add(key, new Vertex(key));
            }

            return _vertexDictionary[key];
        }

        #endregion

        #region Miscellaneous methods

        private void ResetVertexDictionary()
        {
            foreach (var vertex in _vertexDictionary.Values)
            {
                vertex.Distance = double.PositiveInfinity;
                vertex.PreviousVertex = null;
            }
        }

        public void DrawGraph()
        {
            foreach (var keyValuePair in _vertexDictionary)
            {
                var sb = new StringBuilder();
                sb.Append(keyValuePair.Key);
                foreach (var edge in keyValuePair.Value.Edges)
                {
                    sb.Append($" -> {edge.SecondVertex.Name}({edge.Cost})");
                }
                sb.Append(" -|");
                Console.WriteLine(sb.ToString());
            }

            Console.WriteLine();
        }

        #endregion
    }
}
