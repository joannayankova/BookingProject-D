using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingProject.Data.Migrations
{
    public partial class ImageModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ext",
                table: "Images",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ext",
                table: "Images");
        }
    }
}
