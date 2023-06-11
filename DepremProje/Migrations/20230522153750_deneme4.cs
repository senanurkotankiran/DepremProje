using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DepremProje.Migrations
{
    /// <inheritdoc />
    public partial class deneme4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aracs_Kategoris_KategoriId",
                table: "Aracs");

            migrationBuilder.DropIndex(
                name: "IX_Aracs_KategoriId",
                table: "Aracs");

            migrationBuilder.DropColumn(
                name: "KategoriId",
                table: "Aracs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KategoriId",
                table: "Aracs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Aracs_KategoriId",
                table: "Aracs",
                column: "KategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aracs_Kategoris_KategoriId",
                table: "Aracs",
                column: "KategoriId",
                principalTable: "Kategoris",
                principalColumn: "KategoriId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
