using System;
using System.Collections.Generic;

#nullable disable

namespace crudNomina.Data
{
    public partial class Deduccion
    {
        public Deduccion()
        {
            Transaccions = new HashSet<Transaccion>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool DependeSalario { get; set; }
        public double Monto { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Transaccion> Transaccions { get; set; }
    }
}
