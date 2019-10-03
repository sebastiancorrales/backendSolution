using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entidades.Almacén
{
    public class Categoria
    {
        //get es para mostrar el valor del atributo
        //set es para modificar el valor del atributo
        public int idcategoria { get; set; }
        //Las validaciones anteceden el campo
        [Required]
        [StringLength(50, MinimumLength =3,ErrorMessage = "Cantidad de caracteres superior o inferior a los recomendado")]
        public string nombre { get; set; }
        [StringLength(256, MinimumLength = 2, ErrorMessage = "Cantidad de caracteres superior o inferior a los recomendado")]
        public string descripcion { get; set; }
        public bool condicion { get; set; }
    }
}
