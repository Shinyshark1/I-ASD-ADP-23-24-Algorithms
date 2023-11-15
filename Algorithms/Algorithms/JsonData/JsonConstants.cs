using Newtonsoft.Json;
using System.Net;

namespace Algorithms.JsonData
{
    /// <summary>
    /// Provides shorthands to reach the datasets for testing our algorithms.
    /// </summary>
    public static class JsonConstants
    {
        /// <summary>
        /// Reads the 'dataset_sorteren' json file.
        /// </summary>
        /// <returns>The 'dataset_sorteren' contents as a string to use for <see cref="JsonConvert.DeserializeObject(string)"/>.</returns>
        public static string ReadDataSetSorting()
        {
            using (WebClient wc = new WebClient())
            {
                return wc.DownloadString("https://han-aim.gitlab.io/dt-sd-asd/materials/ADP/bron/dataset_sorteren.json");
            }
        }

        /// <summary>
        /// Reads the 'dataset_hashing' json file.
        /// </summary>
        /// <returns>The 'dataset_hashing' contents as a string to use for <see cref="JsonConvert.DeserializeObject(string)"/>.</returns>
        public static string ReadDataSetHashing()
        {
            using (WebClient wc = new WebClient())
            {
                return wc.DownloadString("https://han-aim.gitlab.io/dt-sd-asd/materials/ADP/bron/dataset_hashing.json");
            }
        }

        /// <summary>
        /// Reads the 'dataset_grafen' json file.
        /// </summary>
        /// <returns>The 'dataset_grafen' contents as a string to use for <see cref="JsonConvert.DeserializeObject(string)"/>.</returns>
        public static string ReadDataSetGraphing()
        {
            using (WebClient wc = new WebClient())
            {
                return wc.DownloadString("https://han-aim.gitlab.io/dt-sd-asd/materials/ADP/bron/dataset_grafen.json");
            }
        }
    }
}
