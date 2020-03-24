using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebPersonal.Models
{
    public class Factura
    {
        [Key]
        [Display(Name = ("Número de factura"))]
        public int NumeroFactura { get; set; }
        [Required]
        [Display(Name = ("NIT"))]
        public string Nit { get; set; }
        [Required]
        [Display(Name = ("Fecha"))]
        public DateTime Fecha { get; set; }
        [Required]
        [Display(Name = ("Total"))]
        public decimal Total { get; set; }
        public virtual DetalleFactura DetalleFactura { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
