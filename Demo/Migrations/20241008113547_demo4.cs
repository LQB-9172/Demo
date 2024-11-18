using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Migrations
{
    /// <inheritdoc />
    public partial class demo4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Progress_Student_StudentID",
                table: "Progress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Progress",
                table: "Progress");

            migrationBuilder.RenameTable(
                name: "Progress",
                newName: "Progresss");

            migrationBuilder.RenameIndex(
                name: "IX_Progress_StudentID",
                table: "Progresss",
                newName: "IX_Progresss_StudentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Progresss",
                table: "Progresss",
                column: "ProgressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Progresss_Student_StudentID",
                table: "Progresss",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Progresss_Student_StudentID",
                table: "Progresss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Progresss",
                table: "Progresss");

            migrationBuilder.RenameTable(
                name: "Progresss",
                newName: "Progress");

            migrationBuilder.RenameIndex(
                name: "IX_Progresss_StudentID",
                table: "Progress",
                newName: "IX_Progress_StudentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Progress",
                table: "Progress",
                column: "ProgressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Progress_Student_StudentID",
                table: "Progress",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
