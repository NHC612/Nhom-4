using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Super_Book_Store.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_Kho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kho",
                columns: table => new
                {
                    BookName = table.Column<string>(type: "TEXT", nullable: false),
                    SoLuong = table.Column<int>(type: "INTEGER", nullable: false),
                    TonKho = table.Column<int>(type: "INTEGER", nullable: false),
                    NhapKho = table.Column<int>(type: "INTEGER", nullable: false),
                    XuatKho = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kho", x => x.BookName);
                });

            migrationBuilder.CreateTable(
                name: "NhaXuatBan",
                columns: table => new
                {
                    NXBName = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaXuatBan", x => x.NXBName);
                });

            migrationBuilder.CreateTable(
                name: "Sach",
                columns: table => new
                {
                    SachID = table.Column<string>(type: "TEXT", nullable: false),
                    SachName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sach", x => x.SachID);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    CodeKhachHang = table.Column<string>(type: "TEXT", nullable: false),
                    KhachHangName = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    SachID = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.CodeKhachHang);
                    table.ForeignKey(
                        name: "FK_KhachHang_Sach_SachID",
                        column: x => x.SachID,
                        principalTable: "Sach",
                        principalColumn: "SachID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_SachID",
                table: "KhachHang",
                column: "SachID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "Kho");

            migrationBuilder.DropTable(
                name: "NhaXuatBan");

            migrationBuilder.DropTable(
                name: "Sach");
        }
    }
}
