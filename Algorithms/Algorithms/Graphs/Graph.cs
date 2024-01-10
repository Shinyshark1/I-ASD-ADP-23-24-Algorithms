using System.Text;

namespace Algorithms.Graphs
{
    public class Graph
    {
        private Dictionary<string, Vertex> _vertexDictionary = new();

        #region Algorithms

        public void GetUnweightedShortestPath(Vertex start, Vertex destination)
        {
            // ???
        }

        public void GetWeightedShortestPath(Vertex start, Vertex destination)
        {
            // ???
        }

        #endregion

        #region CRUD Action 

        /// <summary>
        /// Adds the provided vertex to the <see cref="Graph"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when a vertex with the same name already exists in the graph.</exception>
        public void AddVertex(string vertexName)
        {
            AddVertex(new Vertex(vertexName));
        }

        /// <summary>
        /// Adds the provided vertex to the <see cref="Graph"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when a vertex with the same name already exists in the graph.</exception>
        public void AddVertex(Vertex vertex)
        {
            if (_vertexDictionary.ContainsKey(vertex.Name))
            {
                throw new InvalidOperationException($"Vertex '{vertex.Name}' already exists in the Graph.");
            }

            _vertexDictionary.Add(vertex.Name, vertex);
        }


        /// <summary>
        /// Removes all the edges to the provided vertex and removes it from the Graph.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when no vertex of the provided name exists in the graph.</exception>
        public void RemoveVertex(string vertexName)
        {
            RemoveVertex(new Vertex(vertexName));
        }

        /// <summary>
        /// Removes all the edges to the provided vertex and removes it from the Graph.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when no vertex of the provided name exists in the graph.</exception>
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

        /// <summary>
        /// Links the first vertex to the second vertex with the provided cost.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when a link between the two provided vertices already exists in the graph.</exception>
        public void AddEdge(Vertex firstVertex, Vertex secondVertex, double cost)
        {
            var existingEdge = firstVertex.Edges.FirstOrDefault(x => x.SecondVertex.Equals(secondVertex));
            if (existingEdge != null)
            {
                throw new InvalidOperationException($"A link between vertex '{firstVertex.Name}' and and vertex '{secondVertex.Name} already exists.'");
            }

            firstVertex.Edges.AddLast(new Edge(secondVertex, cost));
        }

        /// <summary>
        /// Unlinks the first vertex from the second vertex.
        /// The first vertex will not be removed if it no longer has any edges, 
        /// use <see cref="RemoveVertex(Vertex)"/> or <see cref="RemoveVertex(string)"/> instead.
        /// </summary>
        /// <returns>True if removing was succesful, false if it wasn't.</returns>
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
                var key = $"V{lineList[i, 0]}";
                Vertex vertex = CreateAndRetrieveKey(key);
                var newVertex = new Vertex($"V{lineList[i, 1]}");

                var cost = 0;
                if (lineList.GetLength(1) == 3)
                {
                    cost = lineList[i, 2];
                }
                vertex.AddEdge(newVertex, cost);
            }
        }

        public void InitiateConnectionList(int[][] connectionList)
        {
            for (int i = 0; i < connectionList.Length; i++)
            {
                var key = $"V{i}";
                var vertex = CreateAndRetrieveKey(key);
                for (int j = 0; j < connectionList[i].Length; j++)
                {
                    var newVertex = new Vertex($"V{connectionList[i][j]}");
                    vertex.AddEdge(newVertex, 0);
                }
            }
        }

        public void InitiateConnectionList(int[][][] connectionList)
        {
            for (int i = 0; i < connectionList.Length; i++)
            {
                var key = $"V{i}";
                var vertex = CreateAndRetrieveKey(key);
                for (int j = 0; j < connectionList[i].Length; j++)
                {
                    var newVertex = new Vertex($"V{connectionList[i][j][0]}");
                    vertex.AddEdge(newVertex, connectionList[i][j][1]);
                }
            }
        }

        public void InitiateMatrixList(int[][] matrixList)
        {
            for (int i = 0; i < matrixList.GetLength(0); i++)
            {
                var key = $"V{i}";
                var vertex = CreateAndRetrieveKey(key);
                for (int j = 0; j < matrixList[i].Length; j++)
                {
                    var cost = matrixList[i][j];
                    if (cost == 0)
                    {
                        continue;
                    }

                    var newVertex = new Vertex($"V{j}");
                    vertex.AddEdge(newVertex, cost);
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

            // New line for the next possible drawing.
            Console.WriteLine();
        }

        #endregion
    }
}
