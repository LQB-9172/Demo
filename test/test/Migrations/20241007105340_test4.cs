using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test.Migrations
{
    /// <inheritdoc />
    public partial class test4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Question_QuestionID",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Student_StudentID",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Teacher_TeacherID",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_QuestionID",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_StudentID",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_TeacherID",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "QuestionID",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "TeacherID",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "ImageID",
                table: "Exercise");

            migrationBuilder.AddColumn<int>(
                name: "ImageID1",
                table: "Teacher",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageID1",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageID1",
                table: "Question",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_ImageID1",
                table: "Teacher",
                column: "ImageID1");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ImageID1",
                table: "Student",
                column: "ImageID1");

            migrationBuilder.CreateIndex(
                name: "IX_Question_ImageID1",
                table: "Question",
                column: "ImageID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Image_ImageID1",
                table: "Question",
                column: "ImageID1",
                principalTable: "Image",
                principalColumn: "ImageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Image_ImageID1",
                table: "Student",
                column: "ImageID1",
                principalTable: "Image",
                principalColumn: "ImageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Image_ImageID1",
                table: "Teacher",
                column: "ImageID1",
                principalTable: "Image",
                principalColumn: "ImageID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Image_ImageID1",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Image_ImageID1",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Image_ImageID1",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_ImageID1",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Student_ImageID1",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Question_ImageID1",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "ImageID1",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "ImageID1",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "ImageID1",
                table: "Question");

            migrationBuilder.AddColumn<int>(
                name: "QuestionID",
                table: "Image",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentID",
                table: "Image",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherID",
                table: "Image",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageID",
                table: "Exercise",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Question_QuestionID",
                table: "Image",
                column: "QuestionID",
                principalTable: "Question",
                principalColumn: "QuestionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Student_StudentID",
                table: "Image",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Teacher_TeacherID",
                table: "Image",
                column: "TeacherID",
                principalTable: "Teacher",
                principalColumn: "TeacherID");
        }
    }
}
