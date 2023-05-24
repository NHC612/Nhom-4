using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Super_Book_Store.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_BookType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Khoss",
                columns: table => new
                {
                    BookID = table.Column<string>(type: "TEXT", nullable: false),
                    TypeBook = table.Column<string>(type: "TEXT", nullable: false),
                    NumberbBook = table.Column<string>(type: "TEXT", nullable: false),
                    LanguageID = table.Column<string>(type: "TEXT", nullable: false),
                    BookStoreExists = table.Column<string>(type: "TEXT", nullable: false),
                    InventoryBook = table.Column<string>(type: "TEXT", nullable: false),
                    ExportBook = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoss", x => x.BookID);
                    table.ForeignKey(
                        name: "FK_Khoss_Language_LanguageID",
                        column: x => x.LanguageID,
                        principalTable: "Language",
                        principalColumn: "LanguageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookType",
                columns: table => new
                {
                    BookID = table.Column<string>(type: "TEXT", nullable: false),
                    TypeBook = table.Column<string>(type: "TEXT", nullable: false),
                    BookTypeNew = table.Column<string>(type: "TEXT", nullable: false),
                    AuthorName = table.Column<string>(type: "TEXT", nullable: false),
                    LanguageID = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookType", x => x.BookID);
                    table.ForeignKey(
                        name: "FK_BookType_Khoss_TypeBook",
                        column: x => x.TypeBook,
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

            migrationBuilder.CreateIndex(
                name: "IX_BookType_LanguageID",
                table: "BookType",
                column: "LanguageID");

            migrationBuilder.CreateIndex(
                name: "IX_BookType_TypeBook",
                table: "BookType",
                column: "TypeBook");

            migrationBuilder.CreateIndex(
                name: "IX_Khoss_LanguageID",
                table: "Khoss",
                column: "LanguageID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookType");

            migrationBuilder.DropTable(
                name: "Khoss");

            migrationBuilder.DropTable(
                name: "Language");
        }
    }
}
