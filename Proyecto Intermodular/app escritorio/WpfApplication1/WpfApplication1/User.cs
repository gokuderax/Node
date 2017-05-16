using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Escritorio
{
    class User
    {
        [JsonProperty("typeUser")]
        public String[] typeUser { get; set; }
        [JsonProperty("_id")]
        public String _id { get; set; }
        [JsonProperty("nifcif")]
        public String nifcif { get; set; }
        [JsonProperty("nombre")]
        public String nombre { get; set; }
        [JsonProperty("apellido1")]
        public String apellido1 { get; set; }
        [JsonProperty("apellido2")]
        public String apellido2 { get; set; }
        [JsonProperty("tipo_via")]
        public String tipo_via { get; set; }
        [JsonProperty("nombre_via")]
        public String nombre_via { get; set; }
        [JsonProperty("numero")]
        public String numero { get; set; }
        [JsonProperty("piso")]
        public String piso{ get; set; }
        [JsonProperty("puerta")]
        public String puerta { get; set; }
        [JsonProperty("cod_postal")]
        public String cod_postal { get; set; }
        [JsonProperty("municipio")]
        public String municipio { get; set; }
        [JsonProperty("provincia")]
        public String provincia { get; set; }
        [JsonProperty("pais")]
        public String pais { get; set; }
        [JsonProperty("telefono1")]
        public String telefono1 { get; set; }
        [JsonProperty("telefono2")]
        public String telefono2 { get; set; }
        [JsonProperty("fax")]
        public String fax { get; set; }
        [JsonProperty("email")]
        public String email { get; set; }
        [JsonProperty("persona_contacto")]
        public String persona_contacto { get; set; }
        [JsonProperty("tipo_cliente")]
        public String tipo_cliente { get; set; }
        [JsonProperty("password")]
        public String password { get; set; }
        [JsonProperty("cargo")]
        public String cargo { get; set; }
        [JsonProperty("observaciones")]
        public String observaciones { get; set; }
    }
}
