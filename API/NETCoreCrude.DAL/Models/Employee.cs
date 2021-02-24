using Newtonsoft.Json;
using System;

namespace NETCoreCrude.DAL.Models
{
    /// <summary>
    ///
    /// </summary>
    public class Employee
    {
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("EmployeeID")]
        public int EmployeeID { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("DocumentTypeID")]
        public int DocumentTypeID { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("DocumentNumber")]
        public string DocumentNumber { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("Name")]
        public string Name { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("LastName")]
        public string LastName { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("BirthDate")]
        public DateTime BirthDate { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("AreaID")]
        public int AreaID { get; set; }
    }
}