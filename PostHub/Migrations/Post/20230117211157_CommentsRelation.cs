using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PostHub.Migrations.Post
{
    public partial class CommentsRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentModel_Posts_PostModelID",
                table: "CommentModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentModel",
                table: "CommentModel");

            migrationBuilder.RenameTable(
                name: "CommentModel",
                newName: "Comments");

            migrationBuilder.RenameColumn(
                name: "PostModelID",
                table: "Comments",
                newName: "PostModelId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentModel_PostModelID",
                table: "Comments",
                newName: "IX_Comments_PostModelId");

            migrationBuilder.AlterColumn<int>(
                name: "PostModelId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostModelId",
                table: "Comments",
                column: "PostModelId",
                principalTable: "Posts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostModelId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PublishDate",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "CommentModel");

            migrationBuilder.RenameColumn(
                name: "PostModelId",
                table: "CommentModel",
                newName: "PostModelID");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_PostModelId",
                table: "CommentModel",
                newName: "IX_CommentModel_PostModelID");

            migrationBuilder.AlterColumn<int>(
                name: "PostModelID",
                table: "CommentModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentModel",
                table: "CommentModel",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModel_Posts_PostModelID",
                table: "CommentModel",
                column: "PostModelID",
                principalTable: "Posts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
