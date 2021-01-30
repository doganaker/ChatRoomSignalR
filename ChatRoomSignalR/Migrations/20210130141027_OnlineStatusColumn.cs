using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatRoomSignalR.Migrations
{
    public partial class OnlineStatusColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OnlineStatus",
                table: "AdminUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OnlineStatus",
                table: "AdminUsers");
        }
    }
}
