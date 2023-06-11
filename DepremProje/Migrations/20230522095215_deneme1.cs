using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DepremProje.Migrations
{
    /// <inheritdoc />
    public partial class deneme1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoris",
                columns: table => new
                {
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategoriAciklamasi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoris", x => x.KategoriId);
                });

            migrationBuilder.CreateTable(
                name: "Sehirs",
                columns: table => new
                {
                    SehirId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SehirAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sehirs", x => x.SehirId);
                });

            migrationBuilder.CreateTable(
                name: "Yetkilis",
                columns: table => new
                {
                    YetkiliId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DogumTarihi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YetkiliKodu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yetkilis", x => x.YetkiliId);
                });

            migrationBuilder.CreateTable(
                name: "Aracs",
                columns: table => new
                {
                    AracId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AracPlaka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AracOzellikleri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aracs", x => x.AracId);
                    table.ForeignKey(
                        name: "FK_Aracs_Kategoris_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategoris",
                        principalColumn: "KategoriId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Malzemes",
                columns: table => new
                {
                    MalzemeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MalzemeAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MalzemeAciklamasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MalzemeStokAdedi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Malzemes", x => x.MalzemeId);
                    table.ForeignKey(
                        name: "FK_Malzemes_Kategoris_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategoris",
                        principalColumn: "KategoriId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ilces",
                columns: table => new
                {
                    IlceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IlceAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SehirId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilces", x => x.IlceId);
                    table.ForeignKey(
                        name: "FK_Ilces_Sehirs_SehirId",
                        column: x => x.SehirId,
                        principalTable: "Sehirs",
                        principalColumn: "SehirId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Taleps",
                columns: table => new
                {
                    TalepId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KisiTC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KisiAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KisiSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KisiDogumTarihi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SehirId = table.Column<int>(type: "int", nullable: false),
                    TalepAcikAdresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MalzemeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taleps", x => x.TalepId);
                    table.ForeignKey(
                        name: "FK_Taleps_Malzemes_MalzemeId",
                        column: x => x.MalzemeId,
                        principalTable: "Malzemes",
                        principalColumn: "MalzemeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Taleps_Sehirs_SehirId",
                        column: x => x.SehirId,
                        principalTable: "Sehirs",
                        principalColumn: "SehirId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aracs_KategoriId",
                table: "Aracs",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Ilces_SehirId",
                table: "Ilces",
                column: "SehirId");

            migrationBuilder.CreateIndex(
                name: "IX_Malzemes_KategoriId",
                table: "Malzemes",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Taleps_MalzemeId",
                table: "Taleps",
                column: "MalzemeId");

            migrationBuilder.CreateIndex(
                name: "IX_Taleps_SehirId",
                table: "Taleps",
                column: "SehirId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aracs");

            migrationBuilder.DropTable(
                name: "Ilces");

            migrationBuilder.DropTable(
                name: "Taleps");

            migrationBuilder.DropTable(
                name: "Yetkilis");

            migrationBuilder.DropTable(
                name: "Malzemes");

            migrationBuilder.DropTable(
                name: "Sehirs");

            migrationBuilder.DropTable(
                name: "Kategoris");
        }
    }
}
