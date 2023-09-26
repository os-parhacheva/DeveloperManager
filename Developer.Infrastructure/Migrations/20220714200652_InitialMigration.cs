using System;
using Microsoft.EntityFrameworkCore.Migrations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

#nullable disable

namespace Developer.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessonNumber = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LaborIntensity = table.Column<int>(type: "int", nullable: false),
                    LessonType = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TheoryBlock_ContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TheoryBlock_ContentType = table.Column<int>(type: "int", nullable: false),
                    TheoryBlock_ReadOnly = table.Column<bool>(type: "bit", nullable: false),
                    TheoryBlock_ServiceUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subject_FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject_ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseBlocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubType = table.Column<int>(type: "int", nullable: false),
                    ExerciseType = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content_ContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content_ContentType = table.Column<int>(type: "int", nullable: false),
                    Content_ReadOnly = table.Column<bool>(type: "bit", nullable: false),
                    Content_ServiceUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseBlocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseBlocks_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExerciseNumber = table.Column<int>(type: "int", nullable: false),
                    DifficultyCoefficient = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Content_ContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content_ContentType = table.Column<int>(type: "int", nullable: false),
                    Content_ReadOnly = table.Column<bool>(type: "bit", nullable: false),
                    Content_ServiceUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Test_TestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Test_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Test_ServiceUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExerciseBlockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_ExerciseBlocks_ExerciseBlockId",
                        column: x => x.ExerciseBlockId,
                        principalTable: "ExerciseBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OptionNumber = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Format = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseOptions_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                    principalColumn: "Id",
                        onUpdate: ReferentialAction.Cascade, //добавила
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseVariants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VariantNumber = table.Column<int>(type: "int", nullable: false),
                    DifficultyCoefficient = table.Column<int>(type: "int", nullable: false),
                    Content_ContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content_ContentType = table.Column<int>(type: "int", nullable: false),
                    Content_ReadOnly = table.Column<bool>(type: "bit", nullable: false),
                    Content_ServiceUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseVariants_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseBlocks_LessonId",
                table: "ExerciseBlocks",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseOptions_ExerciseId",
                table: "ExerciseOptions",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_ExerciseBlockId",
                table: "Exercises",
                column: "ExerciseBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseVariants_ExerciseId",
                table: "ExerciseVariants",
                column: "ExerciseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseOptions");

            migrationBuilder.DropTable(
                name: "ExerciseVariants");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "ExerciseBlocks");

            migrationBuilder.DropTable(
                name: "Lessons");
        }
    }
}
