using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace snitch_9000.Migrations
{
    public partial class Courses_Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_COURSES_QUESTIONS_question_id",
                table: "COURSES");

            migrationBuilder.DropForeignKey(
                name: "FK_COURSES_USERS_user_id",
                table: "COURSES");

            migrationBuilder.DropIndex(
                name: "IX_COURSES_question_id",
                table: "COURSES");

            migrationBuilder.DropIndex(
                name: "IX_COURSES_user_id",
                table: "COURSES");

            migrationBuilder.DropColumn(
                name: "question_id",
                table: "COURSES");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "COURSES");

            migrationBuilder.CreateTable(
                name: "CourseQuestion",
                columns: table => new
                {
                    coursescourse_id = table.Column<string>(type: "TEXT", nullable: false),
                    question_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseQuestion", x => new { x.coursescourse_id, x.question_id });
                    table.ForeignKey(
                        name: "FK_CourseQuestion_COURSES_coursescourse_id",
                        column: x => x.coursescourse_id,
                        principalTable: "COURSES",
                        principalColumn: "course_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseQuestion_QUESTIONS_question_id",
                        column: x => x.question_id,
                        principalTable: "QUESTIONS",
                        principalColumn: "question_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseUser",
                columns: table => new
                {
                    coursescourse_id = table.Column<string>(type: "TEXT", nullable: false),
                    user_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseUser", x => new { x.coursescourse_id, x.user_id });
                    table.ForeignKey(
                        name: "FK_CourseUser_COURSES_coursescourse_id",
                        column: x => x.coursescourse_id,
                        principalTable: "COURSES",
                        principalColumn: "course_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseUser_USERS_user_id",
                        column: x => x.user_id,
                        principalTable: "USERS",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseQuestion_question_id",
                table: "CourseQuestion",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_CourseUser_user_id",
                table: "CourseUser",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseQuestion");

            migrationBuilder.DropTable(
                name: "CourseUser");

            migrationBuilder.AddColumn<int>(
                name: "question_id",
                table: "COURSES",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "COURSES",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_COURSES_question_id",
                table: "COURSES",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_COURSES_user_id",
                table: "COURSES",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_COURSES_QUESTIONS_question_id",
                table: "COURSES",
                column: "question_id",
                principalTable: "QUESTIONS",
                principalColumn: "question_id");

            migrationBuilder.AddForeignKey(
                name: "FK_COURSES_USERS_user_id",
                table: "COURSES",
                column: "user_id",
                principalTable: "USERS",
                principalColumn: "user_id");
        }
    }
}
