using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Torc.Aguilar.BookLibrary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBookTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    total_copies = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    copies_in_use = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    isbn = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
