using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIdenitity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Identity_User_Id",
                table: "Identity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Identity",
                table: "Identity");

            migrationBuilder.RenameTable(
                name: "Identity",
                newName: "Identities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Identities",
                table: "Identities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Identities_User_Id",
                table: "Identities",
                column: "Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Identities_User_Id",
                table: "Identities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Identities",
                table: "Identities");

            migrationBuilder.RenameTable(
                name: "Identities",
                newName: "Identity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Identity",
                table: "Identity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Identity_User_Id",
                table: "Identity",
                column: "Id",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
