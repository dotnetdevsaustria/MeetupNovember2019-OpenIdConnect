using Microsoft.EntityFrameworkCore.Migrations;

namespace BIF4DotNetDemo.Migrations
{
    public partial class AddUserDetialsToToDoItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ToDoItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ToDoItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserSubject",
                table: "ToDoItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "ToDoItems");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ToDoItems");

            migrationBuilder.DropColumn(
                name: "UserSubject",
                table: "ToDoItems");
        }
    }
}
