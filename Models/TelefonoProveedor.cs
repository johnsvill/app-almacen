using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebPersonal.Models
{
    public class TelefonoProveedor
    {
        [Key]
        [Display(Name = ("ID teléfono"))]
        public int CodigoTelefono { get; set; }
        [Required]
        [Display(Name = ("Número de teléfono"))]
        public int NumeroTelefono { get; set; }
        [Required]
        [Display(Name = ("Descripción"))]
        public string Descripcion { get; set; }
        [Required]
        [Display(Name = ("Código de proveedor"))]
        public int CodigoProveedor { get; set; }
        public virtual ICollection<Proveedor> Proveedores { get; set; }
    }
}
