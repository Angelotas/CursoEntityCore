using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoEntityCore.Migrations
{
    public partial class CreacionRelacionUsuarioDetalleUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DetalleUsuarioId",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DetalleUsuario",
                columns: table => new
                {
                    DetalleUsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deporte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mascota = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleUsuario", x => x.DetalleUsuarioId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_DetalleUsuarioId",
                table: "Usuario",
                column: "DetalleUsuarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_DetalleUsuario_DetalleUsuarioId",
                table: "Usuario",
                column: "DetalleUsuarioId",
                principalTable: "DetalleUsuario",
                principalColumn: "DetalleUsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_DetalleUsuario_DetalleUsuarioId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "DetalleUsuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_DetalleUsuarioId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "DetalleUsuarioId",
                table: "Usuario");
        }
    }
}
