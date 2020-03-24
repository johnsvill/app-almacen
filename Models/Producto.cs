using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppWebPersonal.Models
{
    public class Producto
    {
        [Key]
        [Display(Name = ("Código del producto"))]
        public int CodigoProducto { get; set; }
        [Required]
        [Display(Name = ("Código de categoría"))]
        public int CodigoCategoria { get; set; }
        [Required]
        [Display(Name = ("Código de empaque"))]
        public int CodigoEmpaque {get; set;}
        [Display(Name = ("Descripción"))]
        public string Descripcion { get; set; }
        [Required]
        [Display(Name = ("Precio Unitario"))]
        public decimal PrecioUnitario { get; set; }
        [Required]
        [Display(Name = ("Precio por docena"))]
        public decimal PrecioPorDocena { get; set; }
        [Required]
        [Display(Name = ("Precio por mayor"))]
        public decimal PrecioPorMayor { get; set; }
        [Required]
        [Display(Name = ("Existencia"))]
        public int Existencia { get; set; }
        [Required]
        [Display(Name = ("Imagen"))]
        public string Imagen { get; set; }
        public virtual ICollection<Categoria> Categorias { get; set; }
        public virtual Inventario Inventario { get; set; }
        public virtual ICollection<TipoEmpaque> TipoEmpaques { get; set; }
        public virtual DetalleCompra DetalleCompra { get; set; }
        public virtual DetalleFactura DetalleFactura { get; set; }
    }
}
