using Microsoft.EntityFrameworkCore.Migrations;

namespace TopLearn.DataLayer.Migrations
{
    public partial class add_2_filde_For_PermissionsTBL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActionName",
                table: "Permissions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ControllerName",
                table: "Permissions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionName",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "ControllerName",
                table: "Permissions");
        }
    }
}
