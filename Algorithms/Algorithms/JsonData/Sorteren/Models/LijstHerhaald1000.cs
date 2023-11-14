using Newtonsoft.Json;

namespace Algorithms.JsonData.Sorteren.Models;

public class LijstHerhaald1000
{
    [JsonProperty("lijst_herhaald_1000")]
    public List<int> Content { get; set; }
}
