using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations;

/// <inheritdoc />
public partial class AddListsAndUsers : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<Guid>(
            name: "ToDoListId",
            table: "ToDos",
            type: "uuid",
            nullable: false,
            defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

        migrationBuilder.CreateTable(
            name: "Type",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Email = table.Column<string>(type: "text", nullable: false),
                Password = table.Column<string>(type: "text", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Type", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "ToDoLists",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                UserId = table.Column<Guid>(type: "uuid", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ToDoLists", x => x.Id);
                table.ForeignKey(
                    name: "FK_ToDoLists_Type_UserId",
                    column: x => x.UserId,
                    principalTable: "Type",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateIndex(
            name: "IX_ToDos_ToDoListId",
            table: "ToDos",
            column: "ToDoListId");

        migrationBuilder.CreateIndex(
            name: "IX_ToDoLists_UserId",
            table: "ToDoLists",
            column: "UserId");

        migrationBuilder.AddForeignKey(
            name: "FK_ToDos_ToDoLists_ToDoListId",
            table: "ToDos",
            column: "ToDoListId",
            principalTable: "ToDoLists",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_ToDos_ToDoLists_ToDoListId",
            table: "ToDos");

        migrationBuilder.DropTable(
            name: "ToDoLists");

        migrationBuilder.DropTable(
            name: "Type");

        migrationBuilder.DropIndex(
            name: "IX_ToDos_ToDoListId",
            table: "ToDos");

        migrationBuilder.DropColumn(
            name: "ToDoListId",
            table: "ToDos");
    }
}