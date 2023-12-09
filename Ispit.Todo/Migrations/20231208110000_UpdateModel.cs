using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ispit.Todo.Migrations
{
    public partial class UpdateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TodoList_TodoListId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TodoListId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "TodoListId",
                table: "AspNetUsers",
                newName: "TaskItemId");

            migrationBuilder.AddColumn<string>(
                name: "AspUserId",
                table: "TodoList",
                type: "nvarchar(450)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "TaskItemId",
                table: "AspNetUsers",
                newName: "TodoListId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TodoListId",
                table: "AspNetUsers",
                column: "TodoListId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TodoList_TodoListId",
                table: "AspNetUsers",
                column: "TodoListId",
                principalTable: "TodoList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
