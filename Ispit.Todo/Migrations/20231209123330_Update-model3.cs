using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ispit.Todo.Migrations
{
    public partial class Updatemodel3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItem_TodoList_TodoListId",
                table: "TaskItem");

            migrationBuilder.AlterColumn<int>(
                name: "TodoListId",
                table: "TaskItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TaskItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItem_TodoList_TodoListId",
                table: "TaskItem",
                column: "TodoListId",
                principalTable: "TodoList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItem_TodoList_TodoListId",
                table: "TaskItem");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TaskItem");

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
    }
}
