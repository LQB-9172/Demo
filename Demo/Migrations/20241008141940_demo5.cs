using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Migrations
{
    /// <inheritdoc />
    public partial class demo5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Exercise_ExerciseID",
                table: "Question");

            migrationBuilder.AddColumn<int>(
                name: "score",
                table: "Test",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseID",
                table: "Question",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AudioUrl",
                table: "Question",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Question",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<bool>(
                name: "completed",
                table: "Lesson",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Audio",
                columns: table => new
                {
                    AudioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AudioUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LessonID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audio", x => x.AudioId);
                    table.ForeignKey(
                        name: "FK_Audio_Lesson_LessonID",
                        column: x => x.LessonID,
                        principalTable: "Lesson",
                        principalColumn: "LessonID");
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LessonID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Image_Lesson_LessonID",
                        column: x => x.LessonID,
                        principalTable: "Lesson",
                        principalColumn: "LessonID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Progresss_LessonID",
                table: "Progresss",
                column: "LessonID");

            migrationBuilder.CreateIndex(
                name: "IX_Progresss_TestID",
                table: "Progresss",
                column: "TestID");

            migrationBuilder.CreateIndex(
                name: "IX_Audio_LessonID",
                table: "Audio",
                column: "LessonID");

            migrationBuilder.CreateIndex(
                name: "IX_Image_LessonID",
                table: "Image",
                column: "LessonID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Exercise_ExerciseID",
                table: "Question",
                column: "ExerciseID",
                principalTable: "Exercise",
                principalColumn: "ExerciseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Progresss_Lesson_LessonID",
                table: "Progresss");

            migrationBuilder.DropForeignKey(
                name: "FK_Progresss_Test_TestID",
                table: "Progresss");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Exercise_ExerciseID",
                table: "Question");

            migrationBuilder.DropTable(
                name: "Audio");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Progresss_LessonID",
                table: "Progresss");

            migrationBuilder.DropIndex(
                name: "IX_Progresss_TestID",
                table: "Progresss");

            migrationBuilder.DropColumn(
                name: "score",
                table: "Test");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "AudioUrl",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "LessonID",
                table: "Progresss");

            migrationBuilder.DropColumn(
                name: "TestID",
                table: "Progresss");

            migrationBuilder.DropColumn(
                name: "completed",
                table: "Lesson");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseID",
                table: "Question",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Exercise_ExerciseID",
                table: "Question",
                column: "ExerciseID",
                principalTable: "Exercise",
                principalColumn: "ExerciseID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
