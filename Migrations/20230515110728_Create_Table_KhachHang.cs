using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Super_Book_Store.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_KhachHang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KhachHang_Sach_SachID",
                table: "KhachHang");

            migrationBuilder.DropTable(
                name: "Sach");

            migrationBuilder.DropIndex(
                name: "IX_KhachHang_SachID",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "SachID",
                table: "KhachHang");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.AddColumn<string>(
                name: "SachID",
                table: "KhachHang",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_SachID",
                table: "KhachHang",
                column: "SachID");

            migrationBuilder.AddForeignKey(
                name: "FK_KhachHang_Sach_SachID",
                table: "KhachHang",
                column: "SachID",
                principalTable: "Sach",
                principalColumn: "SachID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
