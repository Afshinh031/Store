using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TopLearn.DataLayer.Migrations
{
    public partial class upDate_Daatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDelete",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "UserEditorID",
                table: "StoreTypes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StoreTypeEditeDateTime",
                table: "StoreTypes",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<bool>(
                name: "isDelete",
                table: "StoreTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDelete",
                table: "Stores",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "StoreTypeEditeDateTime",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserEditorID",
                table: "Roles",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDelete",
                table: "Roles",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "StoreTypes");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "StoreTypeEditeDateTime",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UserEditorID",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "isDelete",
                table: "Roles");

            migrationBuilder.AlterColumn<int>(
                name: "UserEditorID",
                table: "StoreTypes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StoreTypeEditeDateTime",
                table: "StoreTypes",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
