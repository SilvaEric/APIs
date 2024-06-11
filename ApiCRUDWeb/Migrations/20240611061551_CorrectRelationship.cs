using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCRUDWeb.Migrations
{
    /// <inheritdoc />
    public partial class CorrectRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PetsDetails",
                table: "PetsDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PetsDetails",
                table: "PetsDetails",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PetsDetails_PetId",
                table: "PetsDetails",
                column: "PetId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PetsDetails",
                table: "PetsDetails");

            migrationBuilder.DropIndex(
                name: "IX_PetsDetails_PetId",
                table: "PetsDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PetsDetails",
                table: "PetsDetails",
                column: "PetId");
        }
    }
}
