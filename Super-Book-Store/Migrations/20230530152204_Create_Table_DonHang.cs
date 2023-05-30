using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Super_Book_Store.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_DonHang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.CreateTable(
                name: "DonHang",
                columns: table => new
                {
                    DonHangID = table.Column<string>(type: "TEXT", nullable: false),
                    KhachHangName = table.Column<string>(type: "TEXT", nullable: false),
                    BookNameID = table.Column<string>(type: "TEXT", nullable: false),
                    LanguageID = table.Column<string>(type: "TEXT", nullable: false),
                    NhanVienName = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHang", x => x.DonHangID);
                    table.ForeignKey(
                        name: "FK_DonHang_KhachHang_KhachHangName",
                        column: x => x.KhachHangName,
                        principalTable: "KhachHang",
                        principalColumn: "KhachHangID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonHang_Khoss_BookNameID",
                        column: x => x.BookNameID,
                        principalTable: "Khoss",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonHang_Language_LanguageID",
                        column: x => x.LanguageID,
                        principalTable: "Language",
                        principalColumn: "LanguageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonHang_NhanVien_NhanVienName",
                        column: x => x.NhanVienName,
                        principalTable: "NhanVien",
                        principalColumn: "NhanVienID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_BookNameID",
                table: "DonHang",
                column: "BookNameID");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_KhachHangName",
                table: "DonHang",
                column: "KhachHangName");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_LanguageID",
                table: "DonHang",
                column: "LanguageID");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_NhanVienName",
                table: "DonHang",
                column: "NhanVienName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonHang");

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    HoaDonID = table.Column<string>(type: "TEXT", nullable: false),
                    BookNameID = table.Column<string>(type: "TEXT", nullable: false),
                    KhachHangName = table.Column<string>(type: "TEXT", nullable: false),
                    LanguageID = table.Column<string>(type: "TEXT", nullable: false),
                    NhanVienName = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.HoaDonID);
                    table.ForeignKey(
                        name: "FK_HoaDon_KhachHang_KhachHangName",
                        column: x => x.KhachHangName,
                        principalTable: "KhachHang",
                        principalColumn: "KhachHangID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDon_Khoss_BookNameID",
                        column: x => x.BookNameID,
                        principalTable: "Khoss",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDon_Language_LanguageID",
                        column: x => x.LanguageID,
                        principalTable: "Language",
                        principalColumn: "LanguageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDon_NhanVien_NhanVienName",
                        column: x => x.NhanVienName,
                        principalTable: "NhanVien",
                        principalColumn: "NhanVienID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_BookNameID",
                table: "HoaDon",
                column: "BookNameID");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_KhachHangName",
                table: "HoaDon",
                column: "KhachHangName");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_LanguageID",
                table: "HoaDon",
                column: "LanguageID");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_NhanVienName",
                table: "HoaDon",
                column: "NhanVienName");
        }
    }
}
