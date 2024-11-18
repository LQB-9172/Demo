using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test.Migrations
{
    /// <inheritdoc />
    public partial class test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Image_QuestionID",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_StudentID",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_TeacherID",
                table: "Image");

            migrationBuilder.CreateIndex(
                name: "IX_Image_QuestionID",
                table: "Image",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Image_StudentID",
                table: "Image",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Image_TeacherID",
                table: "Image",
                column: "TeacherID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Image_QuestionID",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_StudentID",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_TeacherID",
                table: "Image");

            migrationBuilder.CreateIndex(
                name: "IX_Image_QuestionID",
                table: "Image",
                column: "QuestionID",
                unique: true,
                filter: "[QuestionID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Image_StudentID",
                table: "Image",
                column: "StudentID",
                unique: true,
                filter: "[StudentID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Image_TeacherID",
                table: "Image",
                column: "TeacherID",
                unique: true,
                filter: "[TeacherID] IS NOT NULL");
        }
    }
}
