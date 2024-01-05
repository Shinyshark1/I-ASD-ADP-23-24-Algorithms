using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.JsonData.Hashing.Models
{
    public class HashtabelsleutelswaardesRoot
    {
        [JsonProperty("hashtabelsleutelswaardes", NullValueHandling = NullValueHandling.Ignore)]
        public Hashtabelsleutelswaardes Hashtabelsleutelswaardes { get; set; }
    }

    public class Hashtabelsleutelswaardes
    {
        [JsonProperty("a", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> A { get; set; }

        [JsonProperty("b", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> B { get; set; }

        [JsonProperty("c", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> C { get; set; }

        [JsonProperty("d", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> D { get; set; }

        [JsonProperty("e", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> E { get; set; }

        [JsonProperty("f", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> F { get; set; }

        [JsonProperty("g", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> G { get; set; }

        [JsonProperty("h", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> H { get; set; }

        [JsonProperty("i", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> I { get; set; }

        [JsonProperty("j", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> J { get; set; }

        [JsonProperty("k", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> K { get; set; }

        [JsonProperty("l", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> L { get; set; }

        [JsonProperty("m", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> M { get; set; }

        [JsonProperty("n", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> N { get; set; }

        [JsonProperty("o", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> O { get; set; }

        [JsonProperty("p", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> P { get; set; }

        [JsonProperty("q", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> Q { get; set; }

        [JsonProperty("r", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> R { get; set; }

        [JsonProperty("s", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> S { get; set; }

        [JsonProperty("t", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> T { get; set; }

        [JsonProperty("u", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> U { get; set; }

        [JsonProperty("v", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> V { get; set; }

        [JsonProperty("w", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> W { get; set; }

        [JsonProperty("x", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> X { get; set; }

        [JsonProperty("y", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> Y { get; set; }

        [JsonProperty("z", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> Z { get; set; }

        [JsonProperty("z0", NullValueHandling = NullValueHandling.Ignore)]
        public List<int> Z0 { get; set; }
    }
}
