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
                name: "BookType",
                columns: table => new
                {
                    BookID = table.Column<string>(type: "TEXT", nullable: false),
                    BookName = table.Column<string>(type: "TEXT", nullable: false),
                    AuthorName = table.Column<string>(type: "TEXT", nullable: false),
                    BookTypeName = table.Column<string>(type: "TEXT", nullable: false),
                    LanguageID = table.Column<string>(type: "TEXT", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_BookType_LanguageID",
                table: "BookType",
                column: "LanguageID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookType");
        }
    }
}
