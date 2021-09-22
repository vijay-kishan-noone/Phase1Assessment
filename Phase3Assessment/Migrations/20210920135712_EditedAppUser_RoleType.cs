using Microsoft.EntityFrameworkCore.Migrations;

namespace Phase3Assessment.Migrations
{
    public partial class EditedAppUser_RoleType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoleType",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleType",
                table: "AspNetUsers");
        }
    }
}
