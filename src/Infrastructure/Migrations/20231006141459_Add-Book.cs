using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Book_BookId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Geners_GenerId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Reservation_ReservationId",
                table: "Book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "Books");

            migrationBuilder.RenameIndex(
                name: "IX_Book_ReservationId",
                table: "Books",
                newName: "IX_Books_ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_GenerId",
                table: "Books",
                newName: "IX_Books_GenerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Books_BookId",
                table: "Authors",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Geners_GenerId",
                table: "Books",
                column: "GenerId",
                principalTable: "Geners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Reservation_ReservationId",
                table: "Books",
                column: "ReservationId",
                principalTable: "Reservation",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Books_BookId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Geners_GenerId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Reservation_ReservationId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Book");

            migrationBuilder.RenameIndex(
                name: "IX_Books_ReservationId",
                table: "Book",
                newName: "IX_Book_ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_GenerId",
                table: "Book",
                newName: "IX_Book_GenerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Book_BookId",
                table: "Authors",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Geners_GenerId",
                table: "Book",
                column: "GenerId",
                principalTable: "Geners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Reservation_ReservationId",
                table: "Book",
                column: "ReservationId",
                principalTable: "Reservation",
                principalColumn: "Id");
        }
    }
}
