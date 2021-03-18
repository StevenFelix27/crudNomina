using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace crudNomina.Models
{
    [Table(name:"Empleado")]
    public class Empleado
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="La cedula es obligatoria")]
        public string Cedula { get; set; }
        [Required(ErrorMessage = "La cedula es obligatoria")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El nombre es obligatoria")]
        public float Salario { get; set; }
        [Required(ErrorMessage = "El salario es obligatoria")]
        public int IdNomina { get; set; }

    }
}
