using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppFoodIOS.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public int tipo_usuario { get; set; }
        public int estado { get; set; }
        public string img { get; set; }
        public string password { get; set; }
        public string website_url { get; set; }
        public string youtube_url { get; set; }
        public int cantRecetas { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_actualizacion { get; set; }   

    }
}