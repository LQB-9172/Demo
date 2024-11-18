using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test.Migrations
{
    /// <inheritdoc />
    public partial class dbtest2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Audio_AudioID",
                table: "Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Image_ImageID",
                table: "Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Image_ImageID",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Image_ImagesImageID",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_ImagesImageID",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Question_ImageID",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_AudioID",
                table: "Exercise");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_ImageID",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "ImagesImageID",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "ImageID",
                table: "Question");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseID",
                table: "Image",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionID",
                table: "Image",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherID",
                table: "Image",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExerciseID",
                table: "Audio",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Image_ExerciseID",
                table: "Image",
                column: "ExerciseID");

            migrationBuilder.CreateIndex(
                name: "IX_Image_QuestionID",
                table: "Image",
                column: "QuestionID",
                unique: true,
                filter: "[QuestionID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Image_TeacherID",
                table: "Image",
                column: "TeacherID",
                unique: true,
                filter: "[TeacherID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Audio_ExerciseID",
                table: "Audio",
                column: "ExerciseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Audio_Exercise_ExerciseID",
                table: "Audio",
                column: "ExerciseID",
                principalTable: "Exercise",
                principalColumn: "ExerciseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Exercise_ExerciseID",
                table: "Image",
                column: "ExerciseID",
                principalTable: "Exercise",
                principalColumn: "ExerciseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Question_QuestionID",
                table: "Image",
                column: "QuestionID",
                principalTable: "Question",
                principalColumn: "QuestionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Teacher_TeacherID",
                table: "Image",
                column: "TeacherID",
                principalTable: "Teacher",
                principalColumn: "TeacherID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Audio_Exercise_ExerciseID",
                table: "Audio");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Exercise_ExerciseID",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Question_QuestionID",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Teacher_TeacherID",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_ExerciseID",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_QuestionID",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_TeacherID",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Audio_ExerciseID",
                table: "Audio");

            migrationBuilder.DropColumn(
                name: "ExerciseID",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "QuestionID",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "TeacherID",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "ExerciseID",
                table: "Audio");

            migrationBuilder.AddColumn<int>(
                name: "ImagesImageID",
                table: "Teacher",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageID",
                table: "Question",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_ImagesImageID",
                table: "Teacher",
                column: "ImagesImageID");

            migrationBuilder.CreateIndex(
                name: "IX_Question_ImageID",
                table: "Question",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_AudioID",
                table: "Exercise",
                column: "AudioID");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_ImageID",
                table: "Exercise",
                column: "ImageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Audio_AudioID",
                table: "Exercise",
                column: "AudioID",
                principalTable: "Audio",
                principalColumn: "AudioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Image_ImageID",
                table: "Exercise",
                column: "ImageID",
                principalTable: "Image",
                principalColumn: "ImageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Image_ImageID",
                table: "Question",
                column: "ImageID",
                principalTable: "Image",
                principalColumn: "ImageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Image_ImagesImageID",
                table: "Teacher",
                column: "ImagesImageID",
                principalTable: "Image",
                principalColumn: "ImageID");
        }
    }
}
