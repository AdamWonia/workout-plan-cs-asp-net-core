using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProject.Data.Migrations
{
    public partial class ProjectDatabase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BackExercises",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BackPart = table.Column<string>(nullable: true),
                    ExerciseName = table.Column<string>(nullable: true),
                    Reps = table.Column<int>(nullable: false),
                    BreakTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackExercises", x => x.ExerciseId);
                });

            migrationBuilder.CreateTable(
                name: "ChestExercises",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChestPart = table.Column<string>(nullable: true),
                    ExerciseName = table.Column<string>(nullable: true),
                    Reps = table.Column<int>(nullable: false),
                    BreakTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChestExercises", x => x.ExerciseId);
                });

            migrationBuilder.CreateTable(
                name: "HandsExercises",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HandPart = table.Column<string>(nullable: true),
                    ExerciseName = table.Column<string>(nullable: true),
                    Reps = table.Column<int>(nullable: false),
                    BreakTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HandsExercises", x => x.ExerciseId);
                });

            migrationBuilder.CreateTable(
                name: "LegsExercises",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LegPart = table.Column<string>(nullable: true),
                    ExerciseName = table.Column<string>(nullable: true),
                    Reps = table.Column<int>(nullable: false),
                    BreakTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegsExercises", x => x.ExerciseId);
                });

            migrationBuilder.CreateTable(
                name: "StomachExercises",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StomachPart = table.Column<string>(nullable: true),
                    ExerciseName = table.Column<string>(nullable: true),
                    Reps = table.Column<int>(nullable: false),
                    BreakTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StomachExercises", x => x.ExerciseId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BackExercises");

            migrationBuilder.DropTable(
                name: "ChestExercises");

            migrationBuilder.DropTable(
                name: "HandsExercises");

            migrationBuilder.DropTable(
                name: "LegsExercises");

            migrationBuilder.DropTable(
                name: "StomachExercises");

            migrationBuilder.CreateTable(
                name: "Farming",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Localization = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farming", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutSection",
                columns: table => new
                {
                    WorkoutSectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreakTime = table.Column<int>(type: "int", nullable: false),
                    ExerciseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExerciseReps = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkoutSectionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutSection", x => x.WorkoutSectionId);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FarmingId = table.Column<int>(type: "int", nullable: false),
                    ImpregnationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sex = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animal_Farming_FarmingId",
                        column: x => x.FarmingId,
                        principalTable: "Farming",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Worker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmploymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndOfEmploymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FarmingId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Worker_Farming_FarmingId",
                        column: x => x.FarmingId,
                        principalTable: "Farming",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_FarmingId",
                table: "Animal",
                column: "FarmingId");

            migrationBuilder.CreateIndex(
                name: "IX_Worker_FarmingId",
                table: "Worker",
                column: "FarmingId");
        }
    }
}
