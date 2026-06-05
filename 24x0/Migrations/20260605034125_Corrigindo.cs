using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace _24x0.Migrations
{
    /// <inheritdoc />
    public partial class Corrigindo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Construtores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Construtores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DesempenhoConstrutoras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ano = table.Column<int>(type: "integer", nullable: false),
                    ForcaBase = table.Column<int>(type: "integer", nullable: false),
                    ConstrutoraId = table.Column<int>(type: "integer", nullable: false),
                    ConstrutorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesempenhoConstrutoras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DesempenhoConstrutoras_Construtores_ConstrutorId",
                        column: x => x.ConstrutorId,
                        principalTable: "Construtores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DesempenhoConstrutoras_ConstrutorId",
                table: "DesempenhoConstrutoras",
                column: "ConstrutorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DesempenhoConstrutoras");

            migrationBuilder.DropTable(
                name: "Construtores");
        }
    }
}
