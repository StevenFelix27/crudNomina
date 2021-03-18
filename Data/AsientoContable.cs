using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace crudNomina.Data
{
    public partial class AsientoContable
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int IdEmpleado { get; set; }
        public string Cuenta { get; set; }
        public string TipoMovimiento { get; set; }
        public DateTime FechaAsiento { get; set; }
        public double MontoAsiento { get; set; }
        public string Estado { get; set; }
        [Display(Name = "Empleado")]
        public virtual Empleado IdEmpleadoNavigation { get; set; }
    }
}
