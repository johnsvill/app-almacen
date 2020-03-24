using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebPersonal.Models
{
    public class Inventario
    {
        [Key]
        [Display(Name = ("Código de inventario"))]
        public int CodigoInventario { get; set; }
        [Required]
        [Display(Name = ("Código de producto"))]
        public int CodigoProducto { get; set; }
        [Display(Name = ("Fecha de ingreso"))]
        public DateTime Fecha { get; set; }
        [Display(Name = ("TipoRegistro de registro"))]
        public string TipoRegistro { get; set; }
        [Display(Name = ("Precio de producto"))]
        public decimal Precio { get; set; }
        [Display(Name = ("Entradas"))]
        public int Entradas { get; set; }
        [Display(Name = ("Salidas"))]
        public int Salidas { get; set; }
    }
}
