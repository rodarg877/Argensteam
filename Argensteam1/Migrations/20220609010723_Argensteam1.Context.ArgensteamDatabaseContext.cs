using Microsoft.EntityFrameworkCore.Migrations;

namespace Argensteam1.Migrations
{
    public partial class Argensteam1ContextArgensteamDatabaseContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Juegos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    urllVideo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imagenes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categoria = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Juegos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Juegos");
        }
    }
}
