﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class CategoriaViewModel
    {
        public int idcategoria { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public bool condicion { get; set; }
    }
}
