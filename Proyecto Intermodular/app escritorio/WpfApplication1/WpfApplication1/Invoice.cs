using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Escritorio
{
    class Invoice
    {
        [JsonProperty("_id")]
        public String _id { get; set; }
        [JsonProperty("id")]
        public String id { get; set; }
        [JsonProperty("id_client")]
        public String id_client { get; set; }
        [JsonProperty("id_shop")]
        public String id_shop { get; set; }
        [JsonProperty("id_salesperson")]
        public String id_salesperson { get; set; }
        [JsonProperty("taxes")]
        public String taxes { get; set; }
        [JsonProperty("base_total")]
        public String base_total { get; set; }
        [JsonProperty("base_advanced")]
        public String base_advanced { get; set; }
        [JsonProperty("observations")]
        public String observations { get; set; }
        [JsonProperty("validated")]
        public String validated { get; set; }
        [JsonProperty("date")]
        public String date { get; set; }
        [JsonProperty("products")]
        public String[] products { get; set; }
    }
}
