using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebPersonal.Models
{
    public class Cliente
    {
        [Key]
        [Display(Name = ("NIT"))]
        public string Nit { get; set; }
        [Required]
        [Display(Name = ("DPI"))]
        public string Dpi { get; set; }
        [Required]
        [Display(Name = ("Nombre"))]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = ("Dirección"))]
        public string Direccion { get; set; }
        public virtual Factura Factura { get; set; }
        public virtual EmailCliente EmailCliente { get; set; }
        public virtual TelefonoCliente TelefonoCliente { get; set; }
    }
}
