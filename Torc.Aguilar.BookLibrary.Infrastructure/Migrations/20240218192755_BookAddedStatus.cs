using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Torc.Aguilar.BookLibrary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BookAddedStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Books",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "Want to read");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Books");
        }
    }
}
