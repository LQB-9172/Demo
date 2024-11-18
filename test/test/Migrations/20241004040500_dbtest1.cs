using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test.Migrations
{
    /// <inheritdoc />
    public partial class dbtest1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Image_ImageID",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_ImageID",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "ImageID",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "imageID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "audioID",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "imageID",
                table: "Lesson");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "User",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "User",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "User",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "User",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Teacher",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Teacher",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "teacherID",
                table: "Teacher",
                newName: "TeacherID");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Student",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Student",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "studentID",
                table: "Student",
                newName: "StudentID");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Lesson",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "Lesson",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "lessonID",
                table: "Lesson",
                newName: "LessonID");

            migrationBuilder.AlterColumn<bool>(
                name: "Role",
                table: "User",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ImagesImageID",
                table: "Teacher",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Teacher",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProgressID",
                table: "Lesson",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Image",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LessonID",
                table: "Image",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentID",
                table: "Image",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Audio",
                columns: table => new
                {
                    AudioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AudioURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LessonID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audio", x => x.AudioID);
                    table.ForeignKey(
                        name: "FK_Audio_Lesson_LessonID",
                        column: x => x.LessonID,
                        principalTable: "Lesson",
                        principalColumn: "LessonID");
                });

            migrationBuilder.CreateTable(
                name: "Progress",
                columns: table => new
                {
                    ProgressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    LessonID = table.Column<int>(type: "int", nullable: false),
                    TestID = table.Column<int>(type: "int", nullable: true),
                    CompleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeSpent = table.Column<int>(type: "int", nullable: false),
                    Completed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Progress", x => x.ProgressID);
                    table.ForeignKey(
                        name: "FK_Progress_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    ExerciseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonID = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrectAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnswerType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageID = table.Column<int>(type: "int", nullable: true),
                    AudioID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.ExerciseID);
                    table.ForeignKey(
                        name: "FK_Exercise_Audio_AudioID",
                        column: x => x.AudioID,
                        principalTable: "Audio",
                        principalColumn: "AudioID");
                    table.ForeignKey(
                        name: "FK_Exercise_Image_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Image",
                        principalColumn: "ImageID");
                    table.ForeignKey(
                        name: "FK_Exercise_Lesson_LessonID",
                        column: x => x.LessonID,
                        principalTable: "Lesson",
                        principalColumn: "LessonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    TestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxScore = table.Column<int>(type: "int", nullable: false),
                    ProgressID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.TestID);
                    table.ForeignKey(
                        name: "FK_Test_Progress_ProgressID",
                        column: x => x.ProgressID,
                        principalTable: "Progress",
                        principalColumn: "ProgressID");
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    QuestionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestID = table.Column<int>(type: "int", nullable: false),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectAnswer = table.Column<int>(type: "int", nullable: false),
                    ImageID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.QuestionID);
                    table.ForeignKey(
                        name: "FK_Question_Image_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Image",
                        principalColumn: "ImageID");
                    table.ForeignKey(
                        name: "FK_Question_Test_TestID",
                        column: x => x.TestID,
                        principalTable: "Test",
                        principalColumn: "TestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_ImagesImageID",
                table: "Teacher",
                column: "ImagesImageID");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_UserID",
                table: "Teacher",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_UserID",
                table: "Student",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_ProgressID",
                table: "Lesson",
                column: "ProgressID");

            migrationBuilder.CreateIndex(
                name: "IX_Image_LessonID",
                table: "Image",
                column: "LessonID");

            migrationBuilder.CreateIndex(
                name: "IX_Image_StudentID",
                table: "Image",
                column: "StudentID",
                unique: true,
                filter: "[StudentID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Audio_LessonID",
                table: "Audio",
                column: "LessonID");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_AudioID",
                table: "Exercise",
                column: "AudioID");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_ImageID",
                table: "Exercise",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_LessonID",
                table: "Exercise",
                column: "LessonID");

            migrationBuilder.CreateIndex(
                name: "IX_Progress_StudentID",
                table: "Progress",
                column: "StudentID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_ImageID",
                table: "Question",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_Question_TestID",
                table: "Question",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_Test_ProgressID",
                table: "Test",
                column: "ProgressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Lesson_LessonID",
                table: "Image",
                column: "LessonID",
                principalTable: "Lesson",
                principalColumn: "LessonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Student_StudentID",
                table: "Image",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Progress_ProgressID",
                table: "Lesson",
                column: "ProgressID",
                principalTable: "Progress",
                principalColumn: "ProgressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_User_UserID",
                table: "Student",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Image_ImagesImageID",
                table: "Teacher",
                column: "ImagesImageID",
                principalTable: "Image",
                principalColumn: "ImageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_User_UserID",
                table: "Teacher",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Lesson_LessonID",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_Student_StudentID",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Progress_ProgressID",
                table: "Lesson");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_User_UserID",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Image_ImagesImageID",
                table: "Teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_User_UserID",
                table: "Teacher");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Audio");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "Progress");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_ImagesImageID",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_UserID",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Student_UserID",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_ProgressID",
                table: "Lesson");

            migrationBuilder.DropIndex(
                name: "IX_Image_LessonID",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_StudentID",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "ImagesImageID",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "ProgressID",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "LessonID",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "Image");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "User",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "User",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "User",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "User",
                newName: "userID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Teacher",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Teacher",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "TeacherID",
                table: "Teacher",
                newName: "teacherID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Student",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Student",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "Student",
                newName: "studentID");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Lesson",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Lesson",
                newName: "content");

            migrationBuilder.RenameColumn(
                name: "LessonID",
                table: "Lesson",
                newName: "lessonID");

            migrationBuilder.AlterColumn<int>(
                name: "role",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "ImageID",
                table: "Teacher",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "imageID",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "audioID",
                table: "Lesson",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "imageID",
                table: "Lesson",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_ImageID",
                table: "Teacher",
                column: "ImageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Image_ImageID",
                table: "Teacher",
                column: "ImageID",
                principalTable: "Image",
                principalColumn: "ImageID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
