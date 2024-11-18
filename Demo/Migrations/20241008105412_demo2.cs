using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Migrations
{
    /// <inheritdoc />
    public partial class demo2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Test_Student_StudentID",
                table: "Test");

            migrationBuilder.DropTable(
                name: "Audio");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "Test",
                newName: "ProgressID");

            migrationBuilder.RenameIndex(
                name: "IX_Test_StudentID",
                table: "Test",
                newName: "IX_Test_ProgressID");

            migrationBuilder.AddColumn<int>(
                name: "ProgressID",
                table: "Lesson",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Progress",
                columns: table => new
                {
                    ProgressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    CompletionPercentage = table.Column<double>(type: "float", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_ProgressID",
                table: "Lesson",
                column: "ProgressID");

            migrationBuilder.CreateIndex(
                name: "IX_Progress_StudentID",
                table: "Progress",
                column: "StudentID",
                unique: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lesson_Progress_ProgressID",
                table: "Lesson");

            migrationBuilder.DropForeignKey(
                name: "FK_Test_Progress_ProgressID",
                table: "Test");

            migrationBuilder.DropTable(
                name: "Progress");

            migrationBuilder.DropIndex(
                name: "IX_Lesson_ProgressID",
                table: "Lesson");

            migrationBuilder.DropColumn(
                name: "ProgressID",
                table: "Lesson");

            migrationBuilder.RenameColumn(
                name: "ProgressID",
                table: "Test",
                newName: "StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Test_ProgressID",
                table: "Test",
                newName: "IX_Test_StudentID");

            migrationBuilder.CreateTable(
                name: "Audio",
                columns: table => new
                {
                    AudioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonID = table.Column<int>(type: "int", nullable: false),
                    AudioUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audio", x => x.AudioID);
                    table.ForeignKey(
                        name: "FK_Audio_Lesson_LessonID",
                        column: x => x.LessonID,
                        principalTable: "Lesson",
                        principalColumn: "LessonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ImageID);
                    table.ForeignKey(
                        name: "FK_Image_Lesson_LessonID",
                        column: x => x.LessonID,
                        principalTable: "Lesson",
                        principalColumn: "LessonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Audio_LessonID",
                table: "Audio",
                column: "LessonID");

            migrationBuilder.CreateIndex(
                name: "IX_Image_LessonID",
                table: "Image",
                column: "LessonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Test_Student_StudentID",
                table: "Test",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "StudentID");
        }
    }
}
