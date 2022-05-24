using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookInfos",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookTitle = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    BookAuthor = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BookYear = table.Column<int>(type: "int", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookInfos", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "BookStocks",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookTitle = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    BookAuthor = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BookYear = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    BookTotal = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    BookOut = table.Column<int>(type: "int", maxLength: 2, nullable: false),
                    BookIn = table.Column<int>(type: "int", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookStocks", x => x.BookId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookInfos");

            migrationBuilder.DropTable(
                name: "BookStocks");
        }
    }
}
