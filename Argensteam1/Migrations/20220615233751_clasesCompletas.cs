using Microsoft.EntityFrameworkCore.Migrations;

namespace Argensteam1.Migrations
{
    public partial class clasesCompletas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Noticias",
                columns: table => new
                {
                    NoticiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noticias", x => x.NoticiaId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FotoPerfil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioJuegos",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    JuegoId = table.Column<int>(type: "int", nullable: false),
                    tipoLista = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioJuegos", x => new { x.JuegoId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_UsuarioJuegos_Juegos_JuegoId",
                        column: x => x.JuegoId,
                        principalTable: "Juegos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioJuegos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioJuegos_UsuarioId",
                table: "UsuarioJuegos",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Noticias");

            migrationBuilder.DropTable(
                name: "UsuarioJuegos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
