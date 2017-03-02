using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Escritorio
{
    class Product
    {
        [JsonProperty("_id")]
        public String _id { get; set; }
        [JsonProperty("id")]
        public String id { get; set; }
        [JsonProperty("referencia")]
        public String referencia { get; set; }
        [JsonProperty("nombre")]
        public String nombre { get; set; }
        [JsonProperty("modelo")]
        public String modelo { get; set; }
        [JsonProperty("descripcion")]
        public String descripcion { get; set; }
        [JsonProperty("categoria")]
        public String categoria { get; set; }
        [JsonProperty("importe")]
        public String importe { get; set; }
        [JsonProperty("iva")]
        public String iva { get; set; }
        [JsonProperty("proveedor")]
        public String proveedor { get; set; }
        [JsonProperty("tienda_stock")]
        public ArrayList tienda_stock { get; set; }
    }
}
