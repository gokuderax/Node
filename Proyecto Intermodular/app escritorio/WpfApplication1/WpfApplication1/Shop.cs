using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Escritorio
{
    class Shop
    {
        [JsonProperty("_id")]
        public String _id { get; set; }
        [JsonProperty("id")]
        public String id { get; set; }
        [JsonProperty("nombre_tienda")]
        public String nombre { get; set; }
        [JsonProperty("tipo_via")]
        public String tipo_via { get; set; }
        [JsonProperty("nombre_via")]
        public String nombre_via { get; set; }
        [JsonProperty("numero")]
        public String numero { get; set; }
        [JsonProperty("cod_postal")]
        public String cod_postal { get; set; }
        [JsonProperty("municipio")]
        public String municipio { get; set; }
        [JsonProperty("provincia")]
        public String provincia { get; set; }
        [JsonProperty("pais")]
        public String pais { get; set; }
        [JsonProperty("telefono")]
        public String telefono { get; set; }
        [JsonProperty("fax")]
        public String fax { get; set; }
        [JsonProperty("email")]
        public String email { get; set; }
        [JsonProperty("encargado")]
        public String encargado { get; set; }
    }
}
