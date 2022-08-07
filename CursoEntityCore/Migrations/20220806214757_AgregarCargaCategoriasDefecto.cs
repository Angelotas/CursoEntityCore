using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoEntityCore.Migrations
{
    public partial class AgregarCargaCategoriasDefecto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Id", "Activo", "FechaCreacion", "Name" },
                values: new object[] { 50, true, new DateTime(2022, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Categoria 5" });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Id", "Activo", "FechaCreacion", "Name" },
                values: new object[] { 51, true, new DateTime(2022, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Categoria 6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 51);
        }
    }
}
