using Algorithms.Hashtable;
using Algorithms.JsonData.Hashing.Models;
using Algorithms.JsonData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.JsonData.Grafen.Models;
using Algorithms.Graphs;

namespace Algorithms.Tests
{
    public class GraphTests
    {
        [Fact]
        public void TheDataSets_Fit_InTheGraph()
        {
            var graphJson = JsonConstants.ReadDataSetGraphing();
            var graphData = JsonConvert.DeserializeObject<GraphData>(graphJson) ?? throw new Exception(" The data could not be read.");

            // Line lists
            var graph1 = new Graph();
            graph1.InitiateLineList(graphData.Lijnlijst);
            var graph2 = new Graph();
            graph2.InitiateLineList(graphData.LijnlijstGewogen);

            // Connection lists
            var graph3 = new Graph();
            graph3.InitiateConnectionList(graphData.Verbindingslijst);
            var graph4 = new Graph();
            graph4.InitiateConnectionList(graphData.VerbindingslijstGewogen);

            // Matrix
            var graph5 = new Graph();
            graph5.InitiateMatrixList(graphData.Verbindingsmatrix);
            var graph6 = new Graph();
            graph6.InitiateMatrixList(graphData.VerbindingsmatrixGewogen);
        }
    }
}
