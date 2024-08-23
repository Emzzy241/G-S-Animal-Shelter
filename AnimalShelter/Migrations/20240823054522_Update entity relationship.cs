using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalShelter.Migrations
{
    public partial class Updateentityrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalDetails_Animals_AnimalId",
                table: "AnimalDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Animals",
                table: "Animals");

            migrationBuilder.RenameTable(
                name: "Animals",
                newName: "AllAnimals");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "AnimalDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllAnimals",
                table: "AllAnimals",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalDetails_AllAnimals_AnimalId",
                table: "AnimalDetails",
                column: "AnimalId",
                principalTable: "AllAnimals",
                principalColumn: "AnimalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalDetails_AllAnimals_AnimalId",
                table: "AnimalDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AllAnimals",
                table: "AllAnimals");

            migrationBuilder.RenameTable(
                name: "AllAnimals",
                newName: "Animals");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "AnimalDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Animals",
                table: "Animals",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalDetails_Animals_AnimalId",
                table: "AnimalDetails",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "AnimalId");
        }
    }
}
