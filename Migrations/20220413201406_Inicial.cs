using Microsoft.EntityFrameworkCore.Migrations;

namespace DepositoComputadores.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LOCAIS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOCAIS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EQUIPAMENTOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeroPatrimonio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EQUIPAMENTOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EQUIPAMENTOS_LOCAIS_LocalId",
                        column: x => x.LocalId,
                        principalTable: "LOCAIS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EQUIPAMENTOS_LocalId",
                table: "EQUIPAMENTOS",
                column: "LocalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EQUIPAMENTOS");

            migrationBuilder.DropTable(
                name: "LOCAIS");
        }
    }
}
