using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookshelf.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PagesRead = table.Column<int>(type: "INTEGER", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false),
                    Review = table.Column<string>(type: "varchar(2048)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "varchar(45)", nullable: true),
                    LastName = table.Column<string>(type: "varchar(45)", nullable: true),
                    AuthorBookId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authors_AuthorBooks_AuthorBookId",
                        column: x => x.AuthorBookId,
                        principalTable: "AuthorBooks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "varchar(255)", nullable: true),
                    Description = table.Column<string>(type: "varchar(2200)", nullable: true),
                    Pages = table.Column<int>(type: "INTEGER", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AuthorBookId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserBookId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_AuthorBooks_AuthorBookId",
                        column: x => x.AuthorBookId,
                        principalTable: "AuthorBooks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Books_UserBooks_UserBookId",
                        column: x => x.UserBookId,
                        principalTable: "UserBooks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "varchar(45)", nullable: true),
                    Surname = table.Column<string>(type: "varchar(45)", nullable: true),
                    Login = table.Column<string>(type: "varchar(128)", nullable: true),
                    Password = table.Column<string>(type: "varchar(128)", nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserBookId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserBooks_UserBookId",
                        column: x => x.UserBookId,
                        principalTable: "UserBooks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_AuthorBookId",
                table: "Authors",
                column: "AuthorBookId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorBookId",
                table: "Books",
                column: "AuthorBookId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_UserBookId",
                table: "Books",
                column: "UserBookId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserBookId",
                table: "Users",
                column: "UserBookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AuthorBooks");

            migrationBuilder.DropTable(
                name: "UserBooks");
        }
    }
}
