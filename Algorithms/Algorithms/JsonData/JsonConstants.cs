using Newtonsoft.Json;

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
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string jsonFilePath = Path.Combine(baseDir, @"..\..\..\JsonData\Sorteren\dataset_sorteren.json");
            return File.ReadAllText(jsonFilePath);
        }

        /// <summary>
        /// Reads the 'dataset_hashing' json file.
        /// </summary>
        /// <returns>The 'dataset_hashing' contents as a string to use for <see cref="JsonConvert.DeserializeObject(string)"/>.</returns>
        public static string ReadDataSetHashing()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string jsonFilePath = Path.Combine(baseDir, @"..\..\..\JsonData\Hashing\dataset_hashing.json");
            return File.ReadAllText(jsonFilePath);
        }

        /// <summary>
        /// Reads the 'dataset_grafen' json file.
        /// </summary>
        /// <returns>The 'dataset_grafen' contents as a string to use for <see cref="JsonConvert.DeserializeObject(string)"/>.</returns>
        public static string ReadDataSetGraphing()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string jsonFilePath = Path.Combine(baseDir, @"..\..\..\JsonData\Grafen\dataset_grafen.json");
            return File.ReadAllText(jsonFilePath);
        }
    }
}
