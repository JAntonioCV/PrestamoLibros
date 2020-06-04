using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrestamoLibros.Models
{
    [Table ("CopiasDeLibro", Schema = "prest")]
    public partial class CopiaDeLibro
    {
        //Constructor de la clase

        //Agregando los atributos de la clase
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El número de copia debe ser mayor a 1")]
        [Display(Name ="Numero de copia")]
        public int NumeroCopia { get; set; }

        //Foreign Key
        public int LibroId { get; set; }

        //Padres
        public virtual Libro Libro { get; set; }

        //Hijos
    }
}