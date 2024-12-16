using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Migrations
{
    /// <inheritdoc />
    public partial class del : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listening_Exercise_ExerciseID",
                table: "Listening");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropIndex(
                name: "IX_Listening_ExerciseID",
                table: "Listening");

            migrationBuilder.DropColumn(
                name: "ExerciseID",
                table: "Listening");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExerciseID",
                table: "Listening",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    ExerciseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonID = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.ExerciseID);
                    table.ForeignKey(
                        name: "FK_Exercise_Lesson_LessonID",
                        column: x => x.LessonID,
                        principalTable: "Lesson",
                        principalColumn: "LessonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Listening_ExerciseID",
                table: "Listening",
                column: "ExerciseID");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_LessonID",
                table: "Exercise",
                column: "LessonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Listening_Exercise_ExerciseID",
                table: "Listening",
                column: "ExerciseID",
                principalTable: "Exercise",
                principalColumn: "ExerciseID");
        }
    }
}
