using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCRUDWeb.Migrations
{
    /// <inheritdoc />
    public partial class addTutorId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Users_TutorUserId",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "TutorUserId",
                table: "Pets",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_TutorUserId",
                table: "Pets",
                newName: "IX_Pets_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Users_UserId",
                table: "Pets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Users_UserId",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Pets",
                newName: "TutorUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_UserId",
                table: "Pets",
                newName: "IX_Pets_TutorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Users_TutorUserId",
                table: "Pets",
                column: "TutorUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
