using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace autoback.infra.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoriaFabricanteAndFKs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Pecas",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Pecas",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Pecas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FabricanteId",
                table: "Pecas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fabricantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricantes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pecas_CategoriaId",
                table: "Pecas",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pecas_Codigo",
                table: "Pecas",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pecas_FabricanteId",
                table: "Pecas",
                column: "FabricanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pecas_Categorias_CategoriaId",
                table: "Pecas",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pecas_Fabricantes_FabricanteId",
                table: "Pecas",
                column: "FabricanteId",
                principalTable: "Fabricantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pecas_Categorias_CategoriaId",
                table: "Pecas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pecas_Fabricantes_FabricanteId",
                table: "Pecas");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Fabricantes");

            migrationBuilder.DropIndex(
                name: "IX_Pecas_CategoriaId",
                table: "Pecas");

            migrationBuilder.DropIndex(
                name: "IX_Pecas_Codigo",
                table: "Pecas");

            migrationBuilder.DropIndex(
                name: "IX_Pecas_FabricanteId",
                table: "Pecas");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Pecas");

            migrationBuilder.DropColumn(
                name: "FabricanteId",
                table: "Pecas");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Pecas",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Pecas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);
        }
    }
}
