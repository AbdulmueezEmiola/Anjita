using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment_3.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Emails",
                table: "Emails");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Emails",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "EmailId",
                table: "Emails",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emails",
                table: "Emails",
                column: "EmailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Emails",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "Emails");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Emails",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emails",
                table: "Emails",
                column: "Email");
        }
    }
}
