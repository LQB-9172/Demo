using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Migrations
{
    /// <inheritdoc />
    public partial class demo3 : Migration
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
                name: "IX_Lesson_ProgressID",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "ProgressID",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "ProgressID",
                table: "Lesson");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
