using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebPersonal.Models
{
    public class TelefonoCliente
    {
        [Key]
        [Display(Name = ("Código de teléfono"))]
        public int CodigoTelefono { get; set; }
        [Required]
        [Display(Name = ("Número de teléfono"))]
        public int NumeroTelefono { get; set; }
        [Required]
        [Display(Name = ("Descripción"))]
        public string Descripcion { get; set; }
        [Required]
        [Display(Name = ("NIT"))]
        public string Nit { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
