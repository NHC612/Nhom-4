using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Super_Book_Store.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_Language : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookType");

            migrationBuilder.DropTable(
                name: "NhaXuatBan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kho",
                table: "Kho");

            migrationBuilder.DropColumn(
                name: "NhapKho",
                table: "Kho");

            migrationBuilder.DropColumn(
                name: "SoLuong",
                table: "Kho");

            migrationBuilder.DropColumn(
                name: "TonKho",
                table: "Kho");

            migrationBuilder.DropColumn(
                name: "XuatKho",
                table: "Kho");

            migrationBuilder.RenameTable(
                name: "Kho",
                newName: "Khoss");

            migrationBuilder.AddColumn<string>(
                name: "BookID",
                table: "Khoss",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BookStoreExists",
                table: "Khoss",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExportBook",
                table: "Khoss",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InventoryBook",
                table: "Khoss",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumberbBook",
                table: "Khoss",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Khoss",
                table: "Khoss",
                column: "BookID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Khoss",
                table: "Khoss");

            migrationBuilder.DropColumn(
                name: "BookID",
                table: "Khoss");

            migrationBuilder.DropColumn(
                name: "BookStoreExists",
                table: "Khoss");

            migrationBuilder.DropColumn(
                name: "ExportBook",
                table: "Khoss");

            migrationBuilder.DropColumn(
                name: "InventoryBook",
                table: "Khoss");

            migrationBuilder.DropColumn(
                name: "NumberbBook",
                table: "Khoss");

            migrationBuilder.RenameTable(
                name: "Khoss",
                newName: "Kho");

            migrationBuilder.AddColumn<int>(
                name: "NhapKho",
                table: "Kho",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SoLuong",
                table: "Kho",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TonKho",
                table: "Kho",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "XuatKho",
                table: "Kho",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kho",
                table: "Kho",
                column: "BookName");

            migrationBuilder.CreateTable(
                name: "BookType",
                columns: table => new
                {
                    BookID = table.Column<string>(type: "TEXT", nullable: false),
                    LanguageID = table.Column<string>(type: "TEXT", nullable: false),
                    AuthorName = table.Column<string>(type: "TEXT", nullable: false),
                    BookName = table.Column<string>(type: "TEXT", nullable: false),
                    BookTypeName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookType", x => x.BookID);
                    table.ForeignKey(
                        name: "FK_BookType_Language_LanguageID",
                        column: x => x.LanguageID,
                        principalTable: "Language",
                        principalColumn: "LanguageID",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_BookType_LanguageID",
                table: "BookType",
                column: "LanguageID");
        }
    }
}
