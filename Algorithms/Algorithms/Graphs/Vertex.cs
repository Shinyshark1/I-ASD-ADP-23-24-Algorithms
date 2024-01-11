namespace Algorithms.Graphs
{
    public class Vertex
    {
        public string Name;
        public LinkedList<Edge> Edges = new();

        public double Distance;
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
