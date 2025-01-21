using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaIDT.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarTablaPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Pedidos");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaPedido",
                table: "Pedidos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaPedido",
                table: "Pedidos");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Precio",
                table: "Pedidos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
