using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppFoodIOS.Models
{
    public class Categoria_receta
    {
        public int id { get; set; }
        public int receta_id { get; set; }
        public int categoria_id { get; set; }
    }
}