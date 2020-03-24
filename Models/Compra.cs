using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebPersonal.Models
{
    public class Compra
    {
        [Key]
        [Display(Name = ("Código de compra"))]
        public int IdCompra { get; set; }
        [Required]
        [Display(Name = ("Número de documento"))]
        public int NumeroDocumento { get; set; }
        [Required]
        [Display(Name = ("Código de proveedor"))]
        public int CodigoProveedor { get; set; }
        [Required]
        [Display(Name = ("Fecha"))]
        public DateTime Fecha { get; set; }
        [Required]
        [Display(Name = ("Total"))]
        public decimal Total { get; set; }
        public virtual DetalleCompra DetalleCompra { get; set; }
        public virtual ICollection<Proveedor> Proveedores { get; set; }
    }
}
