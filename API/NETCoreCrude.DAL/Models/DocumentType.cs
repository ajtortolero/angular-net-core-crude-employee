using Newtonsoft.Json;

namespace NETCoreCrude.DAL.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class DocumentType
    {
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("documentTypeID")]
        public int DocumentTypeID { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}