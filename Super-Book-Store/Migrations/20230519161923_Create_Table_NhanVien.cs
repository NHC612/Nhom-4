using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Super_Book_Store.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_NhanVien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Khoss",
                columns: table => new
                {
                    BookID = table.Column<string>(type: "TEXT", nullable: false),
                    BookName = table.Column<string>(type: "TEXT", nullable: false),
                    NumberbBook = table.Column<string>(type: "TEXT", nullable: false),
                    BookStoreExists = table.Column<string>(type: "TEXT", nullable: false),
                    InventoryBook = table.Column<string>(type: "TEXT", nullable: false),
                    ExportBook = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoss", x => x.BookID);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    LanguageID = table.Column<string>(type: "TEXT", nullable: false),
                    LanguageName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.LanguageID);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    NhanVienID = table.Column<string>(type: "TEXT", nullable: false),
                    NhanVienName = table.Column<string>(type: "TEXT", nullable: false),
                    Sex = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.NhanVienID);
                });

            migrationBuilder.CreateTable(
                name: "BookType",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookNameID = table.Column<string>(type: "TEXT", nullable: false),
                    BookTypeNew = table.Column<string>(type: "TEXT", nullable: false),
                    AuthorName = table.Column<string>(type: "TEXT", nullable: false),
                    LanguageID = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookType", x => x.BookID);
                    table.ForeignKey(
                        name: "FK_BookType_Khoss_BookNameID",
                        column: x => x.BookNameID,
                        principalTable: "Khoss",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookType_Language_LanguageID",
                        column: x => x.LanguageID,
                        principalTable: "Language",
                        principalColumn: "LanguageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    KhachHangID = table.Column<string>(type: "TEXT", nullable: false),
                    KhachHangName = table.Column<string>(type: "TEXT", nullable: false),
                    Sex = table.Column<string>(type: "TEXT", nullable: false),
                    BookNameID = table.Column<string>(type: "TEXT", nullable: false),
                    LanguageID = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.KhachHangID);
                    table.ForeignKey(
                        name: "FK_KhachHang_Khoss_BookNameID",
                        column: x => x.BookNameID,
                        principalTable: "Khoss",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KhachHang_Language_LanguageID",
                        column: x => x.LanguageID,
                        principalTable: "Language",
                        principalColumn: "LanguageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    HoaDonID = table.Column<string>(type: "TEXT", nullable: false),
                    KhachHangName = table.Column<string>(type: "TEXT", nullable: false),
                    BookNameID = table.Column<string>(type: "TEXT", nullable: false),
                    LanguageID = table.Column<string>(type: "TEXT", nullable: false),
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookType_BookNameID",
                table: "BookType",
                column: "BookNameID");

            migrationBuilder.CreateIndex(
                name: "IX_BookType_LanguageID",
                table: "BookType",
                column: "LanguageID");

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
                name: "IX_KhachHang_BookNameID",
                table: "KhachHang",
                column: "BookNameID");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_LanguageID",
                table: "KhachHang",
                column: "LanguageID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookType");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "Khoss");

            migrationBuilder.DropTable(
                name: "Language");
        }
    }
}
