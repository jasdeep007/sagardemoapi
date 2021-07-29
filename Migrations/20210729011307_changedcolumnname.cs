using Microsoft.EntityFrameworkCore.Migrations;

namespace sagardemoapi.Migrations
{
    public partial class changedcolumnname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userid",
                table: "Users",
                newName: "id");
        }
    }
}
