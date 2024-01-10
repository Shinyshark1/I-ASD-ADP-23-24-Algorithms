namespace Algorithms.Graphs
{
    public class Graph
    {
        private Dictionary<string, Vertex> _vertexDictionary = new();

        public void InitiateLineList(int[,] lineList)
        {
            for (int i = 0; i < lineList.GetLength(0); i++)
            {
                // If we do not yet have a key for our vertex, we should make it
                var key = $"vertex-{lineList[i, 0]}";
                if (_vertexDictionary.ContainsKey(key) == false)
                {
                    // We add the vertex that starts it all.
                    _vertexDictionary.Add(key, new Vertex(key));
                }

                // We retrieve the vertex that we'll add our edges to.
                var vertex = _vertexDictionary[key];
                var newVertex = new Vertex($"vertex-{lineList[i, 1]}");
                vertex.AddEdge(newVertex, 0);
            }
        }

        public void InitiateConnectionList(int[][] verbindingslijst)
        {
            for (int i = 0; i < verbindingslijst.Length; i++)
            {
                // If we do not yet have a key for our vertex, we should make it
                var key = $"vertex-{i}";
                if (_vertexDictionary.ContainsKey(key) == false)
                {
                    // We add the vertex that starts it all.
                    _vertexDictionary.Add(key, new Vertex(key));
                }

                var vertex = _vertexDictionary[key];
                for (int j = 0; j < verbindingslijst[i].Length; j++)
                {
                    var newVertex = new Vertex($"vertex-{verbindingslijst[i][j]}");
                    vertex.AddEdge(newVertex, 0);
                }
            }
        }
    }
}
