using Newtonsoft.Json;

namespace Algorithms.JsonData.Grafen.Models
{
    public class GraphData
    {
        #region Unweighted Data

        /// <summary>
        /// This is a collection of pairs, where each pair represents an edge between two nodes in the graph. 
        /// For example: 
        ///     [0, 1] means there's an edge between node 0 and node 1.
        ///     [1, 3] means there's an edge between node 1 and 3.
        /// 
        /// "lijnlijst": 
        /// [
        ///     [0, 1],
        ///     [1, 3],
        /// ]
        /// </summary>
        [JsonProperty("lijnlijst")]
        public int[,] Lijnlijst { get; set; }

        /// <summary>
        /// In this representation, for each node (index), you have a list of all other nodes to which it's directly connected.
        /// For example:
        ///     (index 0) [1, 2] means there's an edge between 0 and 1 and an edge between 0 and 2.
        ///     (index 3) [6, 8] means there's an edge between 3 and 6 and an edge between 3 and 8.
        ///     
        /// "verbindingslijst": [[1, 2], [0, 2, 3], [0, 1, 4], [6, 8]]
        /// </summary>
        [JsonProperty("verbindingslijst")]
        public int[][] Verbindingslijst { get; set; }

        /// <summary>
        /// TODO: Explain how this works.
        /// </summary>
        [JsonProperty("verbindingsmatrix")]
        public int[][] Verbindingsmatrix { get; set; }
        #endregion


        #region Weighted Data
        [JsonProperty("lijnlijst_gewogen")]
        public int[,] LijnlijstGewogen { get; set; }

        [JsonProperty("verbindingslijst_gewogen")]
        public int[][][] VerbindingslijstGewogen { get; set; }

        [JsonProperty("verbindingsmatrix_gewogen")]
        public int[][] VerbindingsmatrixGewogen { get; set; }
        #endregion
    }
}
