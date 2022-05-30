using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppFoodIOS.Models
{
    public class Comentario_receta
    {
        public int id { get; set; }
        public int userid { get; set; }
        public int receta_id { get; set; }
        public string comentario { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_actualizacion { get; set; }
    }
}