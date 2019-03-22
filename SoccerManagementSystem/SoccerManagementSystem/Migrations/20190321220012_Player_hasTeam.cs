using Microsoft.EntityFrameworkCore.Migrations;

namespace SoccerManagementSystem.Migrations
{
    public partial class Player_hasTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "hasTeam",
                table: "Players",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hasTeam",
                table: "Players");
        }
    }
}
