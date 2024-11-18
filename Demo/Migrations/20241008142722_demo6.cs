using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Migrations
{
    /// <inheritdoc />
    public partial class demo6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Progresss_Lesson_LessonID",
                table: "Progresss");

            migrationBuilder.DropForeignKey(
                name: "FK_Progresss_Test_TestID",
                table: "Progresss");

            migrationBuilder.DropIndex(
                name: "IX_Progresss_LessonID",
                table: "Progresss");

            migrationBuilder.DropIndex(
                name: "IX_Progresss_StudentID",
                table: "Progresss");

            migrationBuilder.DropIndex(
                name: "IX_Progresss_TestID",
                table: "Progresss");

            migrationBuilder.DropColumn(
                name: "LessonID",
                table: "Progresss");

            migrationBuilder.DropColumn(
                name: "TestID",
                table: "Progresss");

            migrationBuilder.AddColumn<int>(
                name: "ProgressID",
                table: "Test",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProgressID",
                table: "Lesson",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Test_ProgressID",
                table: "Test",
                column: "ProgressID");

            migrationBuilder.CreateIndex(
                name: "IX_Progresss_StudentID",
                table: "Progresss",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_ProgressID",
                table: "Lesson",
                column: "ProgressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Progresss_ProgressID",
                table: "Lesson",
                column: "ProgressID",
                principalTable: "Progresss",
                principalColumn: "ProgressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Test_Progresss_ProgressID",
                table: "Test",
                column: "ProgressID",
                principalTable: "Progresss",
                principalColumn: "ProgressID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Progresss_ProgressID",
                table: "Lesson");

            migrationBuilder.DropForeignKey(
                name: "FK_Test_Progresss_ProgressID",
                table: "Test");

            migrationBuilder.DropIndex(
                name: "IX_Test_ProgressID",
                table: "Test");

            migrationBuilder.DropIndex(
                name: "IX_Progresss_StudentID",
                table: "Progresss");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_ProgressID",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "ProgressID",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "ProgressID",
                table: "Lesson");

            migrationBuilder.AddColumn<int>(
                name: "LessonID",
                table: "Progresss",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TestID",
                table: "Progresss",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Progresss_LessonID",
                table: "Progresss",
                column: "LessonID");

            migrationBuilder.CreateIndex(
                name: "IX_Progresss_StudentID",
                table: "Progresss",
                column: "StudentID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Progresss_TestID",
                table: "Progresss",
                column: "TestID");

            migrationBuilder.AddForeignKey(
                name: "FK_Progresss_Lesson_LessonID",
                table: "Progresss",
                column: "LessonID",
                principalTable: "Lesson",
                principalColumn: "LessonID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Progresss_Test_TestID",
                table: "Progresss",
                column: "TestID",
                principalTable: "Test",
                principalColumn: "TestID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
