using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrestamoLibros.Models
{
    [Table("AlquileresDeLibro", Schema = "prest")]
    public partial class AlquilerDeLibro
    {
        //Agregando los atributos de la clase y sus notaciones
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "La longitud debe ser de 3 dígitos")]
        [Display(Name = "Codigo Alquiler")]
        public string CodigoAlquiler { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de alquiler")]
        public DateTime FechaAlquiler { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de Devolucion")]
        public DateTime FechaRealDevolucion { get; set; }

        //Foreign key
        public int ClienteId { get; set; }
        public int CopiaId { get; set; }

        //Padres
        public virtual Cliente Cliente { get; set; }

        [ForeignKey("CopiaId")]
        public virtual CopiaDeLibro CopiaDeLibro { get; set; }
    }
}