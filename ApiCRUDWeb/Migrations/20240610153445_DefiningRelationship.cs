using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCRUDWeb.Migrations
{
    /// <inheritdoc />
    public partial class DefiningRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Institutions");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PetsDetails",
                table: "PetsDetails");

            migrationBuilder.DropColumn(
                name: "PetDetailsId",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Pets",
                newName: "TutorId");

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "TEXT",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Institution_Adress",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PetId",
                table: "PetsDetails",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PetsDetails",
                table: "PetsDetails",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_TutorId",
                table: "Pets",
                column: "TutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Users_TutorId",
                table: "Pets",
                column: "TutorId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PetsDetails_Pets_PetId",
                table: "PetsDetails",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Users_TutorId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_PetsDetails_Pets_PetId",
                table: "PetsDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PetsDetails",
                table: "PetsDetails");

            migrationBuilder.DropIndex(
                name: "IX_Pets_TutorId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Institution_Adress",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "PetsDetails");

            migrationBuilder.RenameColumn(
                name: "TutorId",
                table: "Pets",
                newName: "UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "PetDetailsId",
                table: "Pets",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PetsDetails",
                table: "PetsDetails",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Institutions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Adress = table.Column<string>(type: "TEXT", nullable: false),
                    Contact = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Adress = table.Column<string>(type: "TEXT", nullable: false),
                    CPF = table.Column<string>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });
        }
    }
}
