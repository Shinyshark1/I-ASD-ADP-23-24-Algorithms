namespace Algorithms.Graphs
{
    public class Edge
    {
        public Vertex SecondVertex;
        public double Cost;

        public Edge(Vertex nextVertex, double cost)
        {
            SecondVertex = nextVertex;
            Cost = cost;
        }
    }
}
