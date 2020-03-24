using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebPersonal.Models
{
    public class TipoEmpaque
    {
        [Key]
        [Display(Name = ("Código de empaque"))]
        public int CodigoEmpaque { get; set; }
        [Required]
        [Display(Name = ("Descripción"))]
        public string Descripcion { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
