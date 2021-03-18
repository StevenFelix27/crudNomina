using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace crudNomina.Data
{
    public partial class Transaccion
    {
        public int Id { get; set; }
        public int IdEmpleado { get; set; }
        public int? IdDeduccion { get; set; }
        public int? IdIngreso { get; set; }
        [Display(Name = "Tipo de Transaccion")]
        public string TipoTransaccion { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
        public string Estado { get; set; }
        [Display(Name = "Deducciones")]
        public virtual Deduccion IdDeduccionNavigation { get; set; }
        [Display(Name = "Empleados")]
        public virtual Empleado IdEmpleadoNavigation { get; set; }
        [Display(Name = "Ingresos")]
        public virtual Ingreso IdIngresoNavigation { get; set; }
    }
}
