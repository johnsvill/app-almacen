using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebPersonal.Models
{
    public class DetalleFactura
    {
        [Key]
        [Display(Name = ("Código detalle"))]
        public int CodigoDetalle { get; set; }
        [Required]
        [Display(Name = ("Número de factura"))]
        public int NumeroFactura { get; set; }
        [Required]
        [Display(Name = ("Código de producto"))]
        public int CodigoProducto { get; set; }
        [Required]
        [Display(Name = ("Cantidad"))]
        public int Cantidad { get; set; }
        [Required]
        [Display(Name = ("Precio"))]
        public decimal Precio { get; set; }
        [Required]
        [Display(Name = ("Descuento"))]
        public decimal Descuento { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
