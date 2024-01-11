namespace Algorithms.Graphs
{
    /// <summary>
    /// Vertex
    /// </summary>
    public class Vertex
    {
        public string Name;
        public LinkedList<Edge> Edges = new();

        /// <summary>
        /// Shortest distance from A
        /// </summary>
        public double Distance;

        /// <summary>
        /// Previous vertex
        /// </summary>
        public Vertex? PreviousVertex = null;

        public Vertex(string name)
        {
            Name = name;
            Distance = double.PositiveInfinity;
        }

        public void AddEdge(Vertex nextVertex, double cost)
        {
            var edge = new Edge(nextVertex, cost);
            Edges.AddLast(edge);
        }
    }
}
