using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoEntityCore.Migrations
{
    public partial class CreacionRelacionArticuloCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Categoria_Id",
                table: "Article",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Article_Categoria_Id",
                table: "Article",
                column: "Categoria_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Categoria_Categoria_Id",
                table: "Article",
                column: "Categoria_Id",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Categoria_Categoria_Id",
                table: "Article");

            migrationBuilder.DropIndex(
                name: "IX_Article_Categoria_Id",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "Categoria_Id",
                table: "Article");
        }
    }
}
