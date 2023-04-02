using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace snitch_9000.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "QUESTIONS",
                columns: table => new
                {
                    question_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    content = table.Column<string>(type: "TEXT", nullable: false),
                    keywords = table.Column<string>(type: "TEXT", nullable: false),
                    user_id = table.Column<int>(type: "INTEGER", nullable: true),
                    start_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    tags = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUESTIONS", x => x.question_id);
                    table.ForeignKey(
                        name: "FK_QUESTIONS_USERS_user_id",
                        column: x => x.user_id,
                        principalTable: "USERS",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "COURSES",
                columns: table => new
                {
                    course_id = table.Column<string>(type: "TEXT", nullable: false),
                    question_id = table.Column<int>(type: "INTEGER", nullable: true),
                    user_id = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COURSES", x => x.course_id);
                    table.ForeignKey(
                        name: "FK_COURSES_QUESTIONS_question_id",
                        column: x => x.question_id,
                        principalTable: "QUESTIONS",
                        principalColumn: "question_id");
                    table.ForeignKey(
                        name: "FK_COURSES_USERS_user_id",
                        column: x => x.user_id,
                        principalTable: "USERS",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "HITS",
                columns: table => new
                {
                    hit_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    link = table.Column<string>(type: "TEXT", nullable: false),
                    question_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HITS", x => x.hit_id);
                    table.ForeignKey(
                        name: "FK_HITS_QUESTIONS_question_id",
                        column: x => x.question_id,
                        principalTable: "QUESTIONS",
                        principalColumn: "question_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NOTIFICATIONS",
                columns: table => new
                {
                    notification_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    user_id = table.Column<int>(type: "INTEGER", nullable: false),
                    question_id = table.Column<int>(type: "INTEGER", nullable: false),
                    hit_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTIFICATIONS", x => x.notification_id);
                    table.ForeignKey(
                        name: "FK_NOTIFICATIONS_HITS_hit_id",
                        column: x => x.hit_id,
                        principalTable: "HITS",
                        principalColumn: "hit_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NOTIFICATIONS_QUESTIONS_question_id",
                        column: x => x.question_id,
                        principalTable: "QUESTIONS",
                        principalColumn: "question_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NOTIFICATIONS_USERS_user_id",
                        column: x => x.user_id,
                        principalTable: "USERS",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COURSES_question_id",
                table: "COURSES",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_COURSES_user_id",
                table: "COURSES",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_HITS_question_id",
                table: "HITS",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_NOTIFICATIONS_hit_id",
                table: "NOTIFICATIONS",
                column: "hit_id");

            migrationBuilder.CreateIndex(
                name: "IX_NOTIFICATIONS_question_id",
                table: "NOTIFICATIONS",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_NOTIFICATIONS_user_id",
                table: "NOTIFICATIONS",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_QUESTIONS_user_id",
                table: "QUESTIONS",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COURSES");

            migrationBuilder.DropTable(
                name: "NOTIFICATIONS");

            migrationBuilder.DropTable(
                name: "HITS");

            migrationBuilder.DropTable(
                name: "QUESTIONS");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}
