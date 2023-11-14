using Newtonsoft.Json;

namespace Algorithms.JsonData.Sorteren.Models;

/// <remarks>
/// This dataset will always be insufficient. You can mix int and double. After all, all ints are doubles. Not all doubles are ints.
/// However, a string is thrown in there. Once again, all ints and doubles can be strings but not all strings are doubles or ints.
/// There is too much mismatch in data type to provide any form of good result at a reasonable effort.
/// </remarks>
public class LijstOnsorteerbaar3
{
    [JsonProperty("lijst_onsorteerbaar_3")]
    public List<object> Content { get; set; }
}
