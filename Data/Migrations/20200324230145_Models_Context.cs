using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppWebPersonal.Data.Migrations
{
    public partial class Models_Context : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetalleCompras",
                columns: table => new
                {
                    IdDetalle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdCompra = table.Column<int>(nullable: false),
                    CodigoProducto = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleCompras", x => x.IdDetalle);
                });

            migrationBuilder.CreateTable(
                name: "DetalleFacturas",
                columns: table => new
                {
                    CodigoDetalle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumeroFactura = table.Column<int>(nullable: false),
                    CodigoProducto = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false),
                    Descuento = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleFacturas", x => x.CodigoDetalle);
                });

            migrationBuilder.CreateTable(
                name: "EmailClientes",
                columns: table => new
                {
                    CodigoEmail = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: false),
                    Nit = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailClientes", x => x.CodigoEmail);
                });

            migrationBuilder.CreateTable(
                name: "EmailProveedores",
                columns: table => new
                {
                    CodigoEmail = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: false),
                    CodigoProveedor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailProveedores", x => x.CodigoEmail);
                });

            migrationBuilder.CreateTable(
                name: "Inventarios",
                columns: table => new
                {
                    CodigoInventario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodigoProducto = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    TipoRegistro = table.Column<string>(nullable: true),
                    Precio = table.Column<decimal>(nullable: false),
                    Entradas = table.Column<int>(nullable: false),
                    Salidas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventarios", x => x.CodigoInventario);
                });

            migrationBuilder.CreateTable(
                name: "TelefonoClientes",
                columns: table => new
                {
                    CodigoTelefono = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumeroTelefono = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false),
                    Nit = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonoClientes", x => x.CodigoTelefono);
                });

            migrationBuilder.CreateTable(
                name: "TelefonoProveedores",
                columns: table => new
                {
                    CodigoTelefono = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumeroTelefono = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false),
                    CodigoProveedor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonoProveedores", x => x.CodigoTelefono);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    IdCompra = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumeroDocumento = table.Column<int>(nullable: false),
                    CodigoProveedor = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    DetalleCompraIdDetalle = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.IdCompra);
                    table.ForeignKey(
                        name: "FK_Compras_DetalleCompras_DetalleCompraIdDetalle",
                        column: x => x.DetalleCompraIdDetalle,
                        principalTable: "DetalleCompras",
                        principalColumn: "IdDetalle",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    NumeroFactura = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nit = table.Column<string>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    DetalleFacturaCodigoDetalle = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.NumeroFactura);
                    table.ForeignKey(
                        name: "FK_Facturas_DetalleFacturas_DetalleFacturaCodigoDetalle",
                        column: x => x.DetalleFacturaCodigoDetalle,
                        principalTable: "DetalleFacturas",
                        principalColumn: "CodigoDetalle",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    CodigoProducto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodigoCategoria = table.Column<int>(nullable: false),
                    CodigoEmpaque = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    PrecioUnitario = table.Column<decimal>(nullable: false),
                    PrecioPorDocena = table.Column<decimal>(nullable: false),
                    PrecioPorMayor = table.Column<decimal>(nullable: false),
                    Existencia = table.Column<int>(nullable: false),
                    Imagen = table.Column<string>(nullable: false),
                    InventarioCodigoInventario = table.Column<int>(nullable: true),
                    DetalleCompraIdDetalle = table.Column<int>(nullable: true),
                    DetalleFacturaCodigoDetalle = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.CodigoProducto);
                    table.ForeignKey(
                        name: "FK_Productos_DetalleCompras_DetalleCompraIdDetalle",
                        column: x => x.DetalleCompraIdDetalle,
                        principalTable: "DetalleCompras",
                        principalColumn: "IdDetalle",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_DetalleFacturas_DetalleFacturaCodigoDetalle",
                        column: x => x.DetalleFacturaCodigoDetalle,
                        principalTable: "DetalleFacturas",
                        principalColumn: "CodigoDetalle",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_Inventarios_InventarioCodigoInventario",
                        column: x => x.InventarioCodigoInventario,
                        principalTable: "Inventarios",
                        principalColumn: "CodigoInventario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    CodigoProveedor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nit = table.Column<string>(nullable: false),
                    RazonSocial = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(nullable: false),
                    PaginaWeb = table.Column<string>(nullable: false),
                    ContactoPrincipal = table.Column<string>(nullable: false),
                    EmailProveedorCodigoEmail = table.Column<int>(nullable: true),
                    CompraIdCompra = table.Column<int>(nullable: true),
                    TelefonoProveedorCodigoTelefono = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.CodigoProveedor);
                    table.ForeignKey(
                        name: "FK_Proveedores_Compras_CompraIdCompra",
                        column: x => x.CompraIdCompra,
                        principalTable: "Compras",
                        principalColumn: "IdCompra",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proveedores_EmailProveedores_EmailProveedorCodigoEmail",
                        column: x => x.EmailProveedorCodigoEmail,
                        principalTable: "EmailProveedores",
                        principalColumn: "CodigoEmail",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proveedores_TelefonoProveedores_TelefonoProveedorCodigoTelefono",
                        column: x => x.TelefonoProveedorCodigoTelefono,
                        principalTable: "TelefonoProveedores",
                        principalColumn: "CodigoTelefono",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Nit = table.Column<string>(nullable: false),
                    Dpi = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(nullable: false),
                    FacturaNumeroFactura = table.Column<int>(nullable: true),
                    EmailClienteCodigoEmail = table.Column<int>(nullable: true),
                    TelefonoClienteCodigoTelefono = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Nit);
                    table.ForeignKey(
                        name: "FK_Clientes_EmailClientes_EmailClienteCodigoEmail",
                        column: x => x.EmailClienteCodigoEmail,
                        principalTable: "EmailClientes",
                        principalColumn: "CodigoEmail",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clientes_Facturas_FacturaNumeroFactura",
                        column: x => x.FacturaNumeroFactura,
                        principalTable: "Facturas",
                        principalColumn: "NumeroFactura",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clientes_TelefonoClientes_TelefonoClienteCodigoTelefono",
                        column: x => x.TelefonoClienteCodigoTelefono,
                        principalTable: "TelefonoClientes",
                        principalColumn: "CodigoTelefono",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CodigoCategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: false),
                    ProductoCodigoProducto = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CodigoCategoria);
                    table.ForeignKey(
                        name: "FK_Categorias_Productos_ProductoCodigoProducto",
                        column: x => x.ProductoCodigoProducto,
                        principalTable: "Productos",
                        principalColumn: "CodigoProducto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipoEmpaques",
                columns: table => new
                {
                    CodigoEmpaque = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: false),
                    ProductoCodigoProducto = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEmpaques", x => x.CodigoEmpaque);
                    table.ForeignKey(
                        name: "FK_TipoEmpaques_Productos_ProductoCodigoProducto",
                        column: x => x.ProductoCodigoProducto,
                        principalTable: "Productos",
                        principalColumn: "CodigoProducto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_ProductoCodigoProducto",
                table: "Categorias",
                column: "ProductoCodigoProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_EmailClienteCodigoEmail",
                table: "Clientes",
                column: "EmailClienteCodigoEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_FacturaNumeroFactura",
                table: "Clientes",
                column: "FacturaNumeroFactura");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_TelefonoClienteCodigoTelefono",
                table: "Clientes",
                column: "TelefonoClienteCodigoTelefono");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_DetalleCompraIdDetalle",
                table: "Compras",
                column: "DetalleCompraIdDetalle");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_DetalleFacturaCodigoDetalle",
                table: "Facturas",
                column: "DetalleFacturaCodigoDetalle");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_DetalleCompraIdDetalle",
                table: "Productos",
                column: "DetalleCompraIdDetalle");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_DetalleFacturaCodigoDetalle",
                table: "Productos",
                column: "DetalleFacturaCodigoDetalle");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_InventarioCodigoInventario",
                table: "Productos",
                column: "InventarioCodigoInventario");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_CompraIdCompra",
                table: "Proveedores",
                column: "CompraIdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_EmailProveedorCodigoEmail",
                table: "Proveedores",
                column: "EmailProveedorCodigoEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_TelefonoProveedorCodigoTelefono",
                table: "Proveedores",
                column: "TelefonoProveedorCodigoTelefono");

            migrationBuilder.CreateIndex(
                name: "IX_TipoEmpaques_ProductoCodigoProducto",
                table: "TipoEmpaques",
                column: "ProductoCodigoProducto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "TipoEmpaques");

            migrationBuilder.DropTable(
                name: "EmailClientes");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "TelefonoClientes");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "EmailProveedores");

            migrationBuilder.DropTable(
                name: "TelefonoProveedores");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "DetalleCompras");

            migrationBuilder.DropTable(
                name: "DetalleFacturas");

            migrationBuilder.DropTable(
                name: "Inventarios");
        }
    }
}
