﻿using Newtonsoft.Json;

namespace Algorithms.JsonData.Sorteren.Models;

public class LijstOplopend10000
{
    [JsonProperty("lijst_oplopend_10000")]
    public List<int> Content { get; set; }
}
