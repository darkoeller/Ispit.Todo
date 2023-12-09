using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ispit.Todo.Migrations
{
    public partial class UpdateModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TaskItem_TaskItemId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoList_AspNetUsers_AspUserId",
                table: "TodoList");

            migrationBuilder.DropIndex(
                name: "IX_TodoList_AspUserId",
                table: "TodoList");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TaskItemId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AspUserId",
                table: "TodoList");

            migrationBuilder.DropColumn(
                name: "TaskItemId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "TaskItemId",
                table: "TaskItem",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TodoListId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskItem_TaskItemId",
                table: "TaskItem",
                column: "TaskItemId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TodoListId",
                table: "AspNetUsers",
                column: "TodoListId",
                unique: true,
                filter: "[TodoListId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TodoList_TodoListId",
                table: "AspNetUsers",
                column: "TodoListId",
                principalTable: "TodoList",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItem_AspNetUsers_TaskItemId",
                table: "TaskItem",
                column: "TaskItemId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TodoList_TodoListId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItem_AspNetUsers_TaskItemId",
                table: "TaskItem");

            migrationBuilder.DropIndex(
                name: "IX_TaskItem_TaskItemId",
                table: "TaskItem");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TodoListId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TaskItemId",
                table: "TaskItem");

            migrationBuilder.DropColumn(
                name: "TodoListId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "AspUserId",
                table: "TodoList",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskItemId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TodoList_AspUserId",
                table: "TodoList",
                column: "AspUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TaskItemId",
                table: "AspNetUsers",
                column: "TaskItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TaskItem_TaskItemId",
                table: "AspNetUsers",
                column: "TaskItemId",
                principalTable: "TaskItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoList_AspNetUsers_AspUserId",
                table: "TodoList",
                column: "AspUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
