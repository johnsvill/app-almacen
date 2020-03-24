using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebPersonal.Models
{
    public class DetalleCompra
    {
        [Key]
        [Display(Name = ("ID de detalle"))]
        public int IdDetalle { get; set; }
        [Required]
        [Display(Name = ("ID de compra"))]
        public int IdCompra { get; set; }
        [Required]
        [Display(Name = ("Código de producto"))]
        public int CodigoProducto { get; set; }
        [Required]
        [Display(Name = ("Cantidad"))]
        public int Cantidad { get; set; }
        [Required]
        [Display(Name = ("Precio"))]
        public decimal Precio { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
