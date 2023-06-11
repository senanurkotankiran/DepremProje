using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DepremProje.Migrations
{
    /// <inheritdoc />
    public partial class deneme2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IlceId",
                table: "Taleps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Taleps_IlceId",
                table: "Taleps",
                column: "IlceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Taleps_Ilces_IlceId",
                table: "Taleps",
                column: "IlceId",
                principalTable: "Ilces",
                principalColumn: "IlceId",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taleps_Ilces_IlceId",
                table: "Taleps");

            migrationBuilder.DropIndex(
                name: "IX_Taleps_IlceId",
                table: "Taleps");

            migrationBuilder.DropColumn(
                name: "IlceId",
                table: "Taleps");
        }
    }
}
