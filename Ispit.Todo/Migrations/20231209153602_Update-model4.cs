using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ispit.Todo.Migrations
{
    public partial class Updatemodel4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItem_TodoList_TodoListId",
                table: "TaskItem");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TaskItem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "TodoListId",
                table: "TaskItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItem_TodoList_TodoListId",
                table: "TaskItem",
                column: "TodoListId",
                principalTable: "TodoList",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItem_TodoList_TodoListId",
                table: "TaskItem");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TaskItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TodoListId",
                table: "TaskItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItem_TodoList_TodoListId",
                table: "TaskItem",
                column: "TodoListId",
                principalTable: "TodoList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
