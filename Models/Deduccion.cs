using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace crudNomina.Models
{
    [Table(name: "Deduccion")]
    public class Deduccion
    {   [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatoria")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La cuenta es obligatoria")]
        [Display(Name ="Depende de salario")]
        public string DependeSalario { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio")]
        public double Monto { get; set; }
        public bool Estado { get; set; }
    }
}
