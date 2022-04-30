using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProject.Data.Migrations
{
    public partial class WorkoutPlanDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BreakTime",
                table: "WorkoutSection",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ExerciseName",
                table: "WorkoutSection",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExerciseReps",
                table: "WorkoutSection",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BreakTime",
                table: "WorkoutSection");

            migrationBuilder.DropColumn(
                name: "ExerciseName",
                table: "WorkoutSection");

            migrationBuilder.DropColumn(
                name: "ExerciseReps",
                table: "WorkoutSection");
        }
    }
}
