namespace Algorithms.Graphs
{
    public class Vertex
    {
        public string Name;
        public LinkedList<Edge> Edges = new();

        //TODO: Make the unweighted and weighted algorithms with these properties.
        private double _distance;
        private Vertex? _previousVertex;

        public Vertex(string name)
        {
            Name = name;
            _distance = double.PositiveInfinity;
        }

        public void AddEdge(Vertex nextVertex, double cost)
        {
            var edge = new Edge(nextVertex, cost);
            Edges.AddLast(edge);
        }
    }
}
