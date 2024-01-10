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

        public void AddVertex(Vertex vertex, IEnumerable<Vertex> links)
        {
            // Retrieve the vertex by name and then add links between that and the other vertices.
        }

        public void RemoveVertex(Vertex vertex)
        {
            // Remove the vertex, unlinking it from the rest.
        }

        public void LinkVertex(Vertex firstVertex, Vertex secondVertex, double? cost = null)
        {
            // Connect Vertex start to Vertex end with cost.
        }

        public void UnlinkVertex(Vertex firstVertex, Vertex secondVertex)
        {
            // Unlink the vertex, removing it if it no longer has any connections.
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
