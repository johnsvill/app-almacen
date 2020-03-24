using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebPersonal.Models
{
    public class EmailProveedor
    {
        [Key]
        [Display(Name = ("Código de email"))]
        public int CodigoEmail { get; set; }
        [[Required]
        [Display(Name = ("Email"))]
        public string Email { get; set; }
        [Required]
        [Display(Name = ("Código de proveedor"))]
        public int CodigoProveedor { get; set; }
        public virtual ICollection<Proveedor> Proveedores { get; set; }
    }
}
