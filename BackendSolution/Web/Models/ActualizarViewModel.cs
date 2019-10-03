﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class ActualizarViewModel
    {
        [Required]
        public int idcategoria { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre no debe tener mas de 50 caracteres ni menos de 3 tres carateres")]
        public string nombre { get; set; }
        [StringLength(256)]
        public string descripcion { get; set; }
    }
}
