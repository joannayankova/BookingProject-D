using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingProject.Data.Migrations
{
    public partial class PlaceAddReviewProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Places",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Places");
        }
    }
}
