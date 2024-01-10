namespace Algorithms.Graphs
{
    public class Vertex
    {
        private string _name;
        private LinkedList<Edge> _edges = new();

        private double _distance;
        private Vertex? _previousVertex;

        public Vertex(string name)
        {
            _name = name;
            _distance = double.PositiveInfinity;
        }

        public void AddEdge(Vertex nextVertex, double cost)
        {
            var edge = new Edge(nextVertex, cost);
            _edges.AddLast(edge);
        }
    }
}
