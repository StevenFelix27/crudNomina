using System;
using System.Collections.Generic;

#nullable disable

namespace crudNomina.Data
{
    public partial class Empleado
    {
        public Empleado()
        {
            AsientoContables = new HashSet<AsientoContable>();
            Transaccions = new HashSet<Transaccion>();
        }

        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public int? Salario { get; set; }
        public string IdNomina { get; set; }

        public virtual ICollection<AsientoContable> AsientoContables { get; set; }
        public virtual ICollection<Transaccion> Transaccions { get; set; }
    }
}
