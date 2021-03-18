using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace crudNomina.Models
{/// <summary>
/// para hacer esto mas eficas hacer la insercion de esta tabla un campo
/// deduccion/ingresos con id-indiceCAmpo ejemplo si selecciono en un
/// radio button que la transaccion sera de deduccion el id en el backend
/// seria id 5-D indicando que ese id se enlaza a la tabla deducciones
/// de lo contrario si fuera de ingreso seria id 5-I 
/// /// </summary>
/// 
    [Table(name: "Transaccion")]
    public class Transaccion
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("IdEmpleado")]
        [Display(Name = "Empleado")]
       
        public Empleado IdEmpleado { get; set; }
        [Display(Name ="Ingresos / Deducciones")]
        public string IdDeduccionIngresos { get; set; }
        [Display(Name ="Tipo de movimiento")]
        public string TipoTransaccion { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
        public string Estado { get; set; }

    }
}
