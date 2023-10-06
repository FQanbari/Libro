using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMemebership : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberShip_User_Id",
                table: "MemberShip");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MemberShip",
                table: "MemberShip");

            migrationBuilder.RenameTable(
                name: "MemberShip",
                newName: "MemberShips");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemberShips",
                table: "MemberShips",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberShips_User_Id",
                table: "MemberShips",
                column: "Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberShips_User_Id",
                table: "MemberShips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MemberShips",
                table: "MemberShips");

            migrationBuilder.RenameTable(
                name: "MemberShips",
                newName: "MemberShip");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemberShip",
                table: "MemberShip",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberShip_User_Id",
                table: "MemberShip",
                column: "Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
