using Newtonsoft.Json;

namespace NETCoreCrude.DAL.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Area
    {
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("areaID")]
        public int AreaID { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}