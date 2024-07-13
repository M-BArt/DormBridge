using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DormBridge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedatabase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Dormitories_DormitorygId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Rooms_RoomId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoomId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Students",
                newName: "StudentAlbum");

            migrationBuilder.RenameIndex(
                name: "IX_Students_StudentId",
                table: "Students",
                newName: "IX_Students_StudentAlbum");

            migrationBuilder.RenameColumn(
                name: "DormitorygId",
                table: "Rooms",
                newName: "DormitoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_DormitorygId",
                table: "Rooms",
                newName: "IX_Rooms_DormitoryId");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Dormitories",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Personnels",
                columns: table => new
                {
                    PresonnelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DormitoryId = table.Column<int>(type: "int", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnels", x => x.PresonnelId);
                    table.ForeignKey(
                        name: "FK_Personnels_Dormitories_DormitoryId",
                        column: x => x.DormitoryId,
                        principalTable: "Dormitories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personnels_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_RoomId",
                table: "Students",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_DormitoryId",
                table: "Personnels",
                column: "DormitoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Personnels_UserId",
                table: "Personnels",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Dormitories_DormitoryId",
                table: "Rooms",
                column: "DormitoryId",
                principalTable: "Dormitories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Rooms_RoomId",
                table: "Students",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_UserId",
                table: "Students",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserGuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Dormitories_DormitoryId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Rooms_RoomId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_UserId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Personnels");

            migrationBuilder.DropIndex(
                name: "IX_Students_RoomId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "StudentAlbum",
                table: "Students",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_StudentAlbum",
                table: "Students",
                newName: "IX_Students_StudentId");

            migrationBuilder.RenameColumn(
                name: "DormitoryId",
                table: "Rooms",
                newName: "DormitorygId");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_DormitoryId",
                table: "Rooms",
                newName: "IX_Rooms_DormitorygId");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Dormitories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoomId",
                table: "Users",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Dormitories_DormitorygId",
                table: "Rooms",
                column: "DormitorygId",
                principalTable: "Dormitories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Rooms_RoomId",
                table: "Users",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }
    }
}
