using Microsoft.EntityFrameworkCore.Migrations;

namespace TopLearn.DataLayer.Migrations
{
    public partial class UpDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StoreTypeEditeDateTime",
                table: "Roles",
                newName: "RoleEditeDateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoleEditeDateTime",
                table: "Roles",
                newName: "StoreTypeEditeDateTime");
        }
    }
}
