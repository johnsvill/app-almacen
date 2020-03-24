using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebPersonal.Models
{
    public class Categoria
    {
        [Key]
        [Display(Name = ("Código de categoría"))]
        public int CodigoCategoria { get; set; }
        [Required]
        [Display(Name = ("Descripción"))]
        public string Descripcion { get; set; }
    }
}
