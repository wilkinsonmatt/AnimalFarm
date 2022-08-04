using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalFarm.Migrations
{
    public partial class updateTrainerColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainerAnimal_Categories_TrainerId",
                table: "TrainerAnimal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Trainers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trainers",
                table: "Trainers",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerAnimal_Trainers_TrainerId",
                table: "TrainerAnimal",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "TrainerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainerAnimal_Trainers_TrainerId",
                table: "TrainerAnimal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trainers",
                table: "Trainers");

            migrationBuilder.RenameTable(
                name: "Trainers",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainerAnimal_Categories_TrainerId",
                table: "TrainerAnimal",
                column: "TrainerId",
                principalTable: "Categories",
                principalColumn: "TrainerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
