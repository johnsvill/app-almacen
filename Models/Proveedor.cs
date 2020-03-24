using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebPersonal.Models
{
    public class Proveedor
    {
        [Key]
        [Display(Name = ("Código de proveedor"))]
        public int CodigoProveedor { get; set; }
        [Required]
        [Display(Name = ("NIT de proveedor"))]
        public string Nit { get; set; }
        [Required]
        [Display(Name = ("Razón social"))]
        public string RazonSocial { get; set; }
        [Required]
        [Display(Name = ("Dirección"))]
        public string Direccion { get; set; }
        [Required]
        [Display(Name = ("Sitio Web"))]
        public string PaginaWeb { get; set; }
        [Required]
        [Display(Name = ("Contacto principal"))]
        public string ContactoPrincipal { get; set; }
        public virtual EmailProveedor EmailProveedor { get; set; }
        public virtual Compra Compra { get; set; }
        public virtual TelefonoProveedor TelefonoProveedor { get; set; }
    }
}
