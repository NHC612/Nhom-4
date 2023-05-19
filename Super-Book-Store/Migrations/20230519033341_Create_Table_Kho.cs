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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Khoss");
        }
    }
}
