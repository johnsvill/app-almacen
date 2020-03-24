using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebPersonal.Models
{
    public class EmailCliente
    {
        [Key]
        [Display(Name = ("ID email"))]
        public int CodigoEmail { get; set; }
        [Required]
        [Display(Name = ("Email"))]
        public string Email { get; set; }
        [Required]
        [Display(Name = ("NIT"))]
        public string Nit { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
