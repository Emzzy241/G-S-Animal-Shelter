using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalShelter.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnimalId",
                table: "AnimalDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnimalDetails_AnimalId",
                table: "AnimalDetails",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimalDetails_Animals_AnimalId",
                table: "AnimalDetails",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "AnimalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimalDetails_Animals_AnimalId",
                table: "AnimalDetails");

            migrationBuilder.DropIndex(
                name: "IX_AnimalDetails_AnimalId",
                table: "AnimalDetails");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                table: "AnimalDetails");
        }
    }
}
