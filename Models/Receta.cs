using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppFoodIOS.Models
{
    public class Receta
    {
        public int id { get; set; }
        public int userid { get; set; }
        public string nombre { get; set; }
        public string img { get; set; }
        public int duracion { get; set; }
        public int nroPlatos { get; set; }
        public int dificula_id { get; set; }
        public int cocina_id { get; set; }
        public string ingredientes { get; set; }
        public string pasos { get; set; }
        public string youtube_url { get; set; }
        public string website_url { get; set; }
        public int nro_vistas { get; set; }
        public int nro_likes { get; set; }
        public int estado_id { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_actualizacion { get; set; }

    }
}