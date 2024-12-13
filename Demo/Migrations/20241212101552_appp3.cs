using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Migrations
{
    /// <inheritdoc />
    public partial class appp3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Lesson_LessonID",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Video_Lesson_LessonID",
                table: "Video");

            migrationBuilder.AlterColumn<int>(
                name: "LessonID",
                table: "Video",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LessonID",
                table: "Image",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Lesson_LessonID",
                table: "Image",
                column: "LessonID",
                principalTable: "Lesson",
                principalColumn: "LessonID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Lesson_LessonID",
                table: "Video",
                column: "LessonID",
                principalTable: "Lesson",
                principalColumn: "LessonID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Lesson_LessonID",
                table: "Image");

            migrationBuilder.DropForeignKey(
                name: "FK_Video_Lesson_LessonID",
                table: "Video");

            migrationBuilder.AlterColumn<int>(
                name: "LessonID",
                table: "Video",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LessonID",
                table: "Image",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Lesson_LessonID",
                table: "Image",
                column: "LessonID",
                principalTable: "Lesson",
                principalColumn: "LessonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Lesson_LessonID",
                table: "Video",
                column: "LessonID",
                principalTable: "Lesson",
                principalColumn: "LessonID");
        }
    }
}
