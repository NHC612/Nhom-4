using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Super_Book_Store.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_HoaDon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NhanVienName",
                table: "HoaDon",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_NhanVienName",
                table: "HoaDon",
                column: "NhanVienName");

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDon_NhanVien_NhanVienName",
                table: "HoaDon",
                column: "NhanVienName",
                principalTable: "NhanVien",
                principalColumn: "NhanVienID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoaDon_NhanVien_NhanVienName",
                table: "HoaDon");

            migrationBuilder.DropIndex(
                name: "IX_HoaDon_NhanVienName",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "NhanVienName",
                table: "HoaDon");
        }
    }
}
