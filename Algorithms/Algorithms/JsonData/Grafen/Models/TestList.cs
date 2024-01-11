using Newtonsoft.Json;

namespace Algorithms.JsonData.Grafen.Models
{
    public class TestList
    {
        [JsonProperty("linelist_weighted")]
        public int[][][] LineListWeighted { get; set; }
    }
}
