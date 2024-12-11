using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Migrations
{
    /// <inheritdoc />
    public partial class up : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Progress_ProgressID",
                table: "Lesson");

            migrationBuilder.DropForeignKey(
                name: "FK_Test_Progress_ProgressID",
                table: "Test");

            migrationBuilder.DropIndex(
                name: "IX_Test_ProgressID",
                table: "Test");

            migrationBuilder.DropIndex(
                name: "IX_Progress_StudentID",
                table: "Progress");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_ProgressID",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "ProgressID",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "ProgressID",
                table: "Lesson");

            migrationBuilder.CreateTable(
                name: "StudentLesson",
                columns: table => new
                {
                    StudentLessonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    LessonID = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLesson", x => x.StudentLessonID);
                    table.ForeignKey(
                        name: "FK_StudentLesson_Lesson_LessonID",
                        column: x => x.LessonID,
                        principalTable: "Lesson",
                        principalColumn: "LessonID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentLesson_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Progress_StudentID",
                table: "Progress",
                column: "StudentID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentLesson_LessonID",
                table: "StudentLesson",
                column: "LessonID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLesson_StudentID",
                table: "StudentLesson",
                column: "StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentLesson");

            migrationBuilder.DropIndex(
                name: "IX_Progress_StudentID",
                table: "Progress");

            migrationBuilder.AddColumn<int>(
                name: "ProgressID",
                table: "Test",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Completed",
                table: "Lesson",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_Progress_StudentID",
                table: "Progress",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_ProgressID",
                table: "Lesson",
                column: "ProgressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Progress_ProgressID",
                table: "Lesson",
                column: "ProgressID",
                principalTable: "Progress",
                principalColumn: "ProgressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Test_Progress_ProgressID",
                table: "Test",
                column: "ProgressID",
                principalTable: "Progress",
                principalColumn: "ProgressID");
        }
    }
}
