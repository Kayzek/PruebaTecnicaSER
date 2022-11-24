using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaBackend.Migrations.ProductoDb
{
    /// <inheritdoc />
    public partial class inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombreProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcionProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precioCordoba = table.Column<double>(type: "float", nullable: false),
                    precioDolar = table.Column<double>(type: "float", nullable: false),
                    estadoProducto = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
