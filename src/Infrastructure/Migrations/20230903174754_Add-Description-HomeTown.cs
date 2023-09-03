using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionHomeTown : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "HomeTown",
                table: "Authors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Authors_HomeTown",
                table: "Authors",
                column: "HomeTown");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Cities_HomeTown",
                table: "Authors",
                column: "HomeTown",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Cities_HomeTown",
                table: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Authors_HomeTown",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "HomeTown",
                table: "Authors");
        }
    }
}
