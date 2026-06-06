using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace _24x0.Migrations
{
    /// <inheritdoc />
    public partial class AddDesempenhos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DesempenhosConstructor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ConstrutorId = table.Column<int>(type: "integer", nullable: false),
                    Ano = table.Column<int>(type: "integer", nullable: false),
                    Pontos = table.Column<double>(type: "double precision", nullable: false),
                    ForcaBase = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesempenhosConstructor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DesempenhosConstructor_Construtores_ConstrutorId",
                        column: x => x.ConstrutorId,
                        principalTable: "Construtores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DesempenhosPiloto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PilotoId = table.Column<int>(type: "integer", nullable: false),
                    Ano = table.Column<int>(type: "integer", nullable: false),
                    Pontos = table.Column<double>(type: "double precision", nullable: false),
                    ForcaBase = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesempenhosPiloto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DesempenhosPiloto_Pilotos_PilotoId",
                        column: x => x.PilotoId,
                        principalTable: "Pilotos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DesempenhosConstructor_ConstrutorId",
                table: "DesempenhosConstructor",
                column: "ConstrutorId");

            migrationBuilder.CreateIndex(
                name: "IX_DesempenhosPiloto_PilotoId",
                table: "DesempenhosPiloto",
                column: "PilotoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DesempenhosConstructor");

            migrationBuilder.DropTable(
                name: "DesempenhosPiloto");
        }
    }
}
