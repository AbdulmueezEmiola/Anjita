using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment_2.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Question = table.Column<string>(nullable: false),
                    Option1 = table.Column<string>(nullable: false),
                    Option2 = table.Column<string>(nullable: false),
                    Option3 = table.Column<string>(nullable: false),
                    Option4 = table.Column<string>(nullable: false),
                    CorrectAnswer = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Question);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
