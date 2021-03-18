using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace crudNomina.Models
{
    [Table(name: "Ingreso")]
    public class Ingresos
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatoria")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La cuenta es obligatoria")]
        [Display(Name = "Depende de salario")]
        public string DependeSalario { get; set; }

        [Required(ErrorMessage = "El monto es obligatorio")]
        public double Monto { get; set; }
        public bool Estado { get; set; }
    }
}
