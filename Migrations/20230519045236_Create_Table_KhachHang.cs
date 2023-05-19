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
            migrationBuilder.DropPrimaryKey(
                name: "PK_KhachHang",
                table: "KhachHang");

            migrationBuilder.RenameColumn(
                name: "CodeKhachHang",
                table: "KhachHang",
                newName: "Sex");

            migrationBuilder.AddColumn<string>(
                name: "KhachHangID",
                table: "KhachHang",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BookNameID",
                table: "KhachHang",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LanguageID",
                table: "KhachHang",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KhachHang",
                table: "KhachHang",
                column: "KhachHangID");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_BookNameID",
                table: "KhachHang",
                column: "BookNameID");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_LanguageID",
                table: "KhachHang",
                column: "LanguageID");

            migrationBuilder.AddForeignKey(
                name: "FK_KhachHang_Khoss_BookNameID",
                table: "KhachHang",
                column: "BookNameID",
                principalTable: "Khoss",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KhachHang_Language_LanguageID",
                table: "KhachHang",
                column: "LanguageID",
                principalTable: "Language",
                principalColumn: "LanguageID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KhachHang_Khoss_BookNameID",
                table: "KhachHang");

            migrationBuilder.DropForeignKey(
                name: "FK_KhachHang_Language_LanguageID",
                table: "KhachHang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KhachHang",
                table: "KhachHang");

            migrationBuilder.DropIndex(
                name: "IX_KhachHang_BookNameID",
                table: "KhachHang");

            migrationBuilder.DropIndex(
                name: "IX_KhachHang_LanguageID",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "KhachHangID",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "BookNameID",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "LanguageID",
                table: "KhachHang");

            migrationBuilder.RenameColumn(
                name: "Sex",
                table: "KhachHang",
                newName: "CodeKhachHang");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KhachHang",
                table: "KhachHang",
                column: "CodeKhachHang");
        }
    }
}
