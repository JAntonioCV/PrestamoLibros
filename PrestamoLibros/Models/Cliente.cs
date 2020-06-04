using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrestamoLibros.Models
{
    [Table("Clientes", Schema = "prest")]
    public partial class Cliente
    {
        //Constructor de la clase
        public Cliente() {
            this.AlquileresDeLibro = new HashSet<AlquilerDeLibro>();
        }

        //Agregando los atributos de la clase y sus notaciones
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "La longitud del campo debe ser de 3 dígitos")]
        [Display(Name ="Codigo")]

        public string CodigoDeCliente { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "La longitud del campo debe ser menor o igual a 50 caracteres")]
        [Display(Name = "Nombres")]
        public string NombresDelCliente { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "La longitud del campo debe ser menor o igual a 50 caracteres")]
        [Display(Name = "Apellidos")]
        public string ApellidosDelCliente { get; set; }

        [NotMapped]
        public string NombreCompleto {get { return NombresDelCliente.Trim() + " " + ApellidosDelCliente.Trim();  } }

        //Hijos
        public virtual ICollection<AlquilerDeLibro> AlquileresDeLibro { get; set; }
    }
}