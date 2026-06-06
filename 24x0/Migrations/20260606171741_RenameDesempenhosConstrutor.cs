using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _24x0.Migrations
{
    /// <inheritdoc />
    public partial class RenameDesempenhosConstrutor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DesempenhosConstructor_Construtores_ConstrutorId",
                table: "DesempenhosConstructor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DesempenhosConstructor",
                table: "DesempenhosConstructor");

            migrationBuilder.RenameTable(
                name: "DesempenhosConstructor",
                newName: "DesempenhosConstrutor");

            migrationBuilder.RenameIndex(
                name: "IX_DesempenhosConstructor_ConstrutorId",
                table: "DesempenhosConstrutor",
                newName: "IX_DesempenhosConstrutor_ConstrutorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DesempenhosConstrutor",
                table: "DesempenhosConstrutor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DesempenhosConstrutor_Construtores_ConstrutorId",
                table: "DesempenhosConstrutor",
                column: "ConstrutorId",
                principalTable: "Construtores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DesempenhosConstrutor_Construtores_ConstrutorId",
                table: "DesempenhosConstrutor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DesempenhosConstrutor",
                table: "DesempenhosConstrutor");

            migrationBuilder.RenameTable(
                name: "DesempenhosConstrutor",
                newName: "DesempenhosConstructor");

            migrationBuilder.RenameIndex(
                name: "IX_DesempenhosConstrutor_ConstrutorId",
                table: "DesempenhosConstructor",
                newName: "IX_DesempenhosConstructor_ConstrutorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DesempenhosConstructor",
                table: "DesempenhosConstructor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DesempenhosConstructor_Construtores_ConstrutorId",
                table: "DesempenhosConstructor",
                column: "ConstrutorId",
                principalTable: "Construtores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
