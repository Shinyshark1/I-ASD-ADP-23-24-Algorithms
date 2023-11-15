using Newtonsoft.Json;

namespace Algorithms.JsonData.Sorteren.Models;

public class LijstWillekeurig10000
{
    [JsonProperty("lijst_willekeurig_10000")]
    public int[] Content { get; set; }
}
