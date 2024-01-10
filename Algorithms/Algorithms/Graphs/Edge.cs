namespace Algorithms.Graphs
{
    public class Edge
    {
        /// <summary>
        /// This is the <see cref="Vertex"/> on the end of our <see cref="Edge"/>.
        /// This makes sense because our <see cref="Edge"/> is added to the first <see cref="Vertex"/> of the edge.
        /// </summary>
        private Vertex _secondVertex;
        private double _cost;

        public Edge(Vertex nextVertex, double cost)
        {
            _secondVertex = nextVertex;
            _cost = cost;
        }
    }
}
