using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Developer.Infrastructure.Migrations
{
    public partial class _29042023 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExerciseType",
                table: "ExerciseBlocks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExerciseType",
                table: "ExerciseBlocks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
