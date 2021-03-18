using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace crudNomina.Models
{
    
    public class AsientoContable
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage ="La descripcion es obligatoria")]
        public string Descripcion { get; set; }
        [ForeignKey("IdEmpleado")]
        [Display(Name ="Empleado")]
    
        public Empleado IdEmpleado { get; set; }
        [Required(ErrorMessage = "La cuenta es obligatoria")]
        public string Cuenta { get; set; }
        [Display(Name ="Tipo de Movimiento")]
        public string TipoMovimiento { get; set; }
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El monto es obligatoria")]
        public double MontoAsiento { get; set; }
        public string Estado { get; set; }
    }
}
