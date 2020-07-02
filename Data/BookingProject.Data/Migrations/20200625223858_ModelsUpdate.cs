using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingProject.Data.Migrations
{
    public partial class ModelsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaceExtrasSets_Places_PlaceId",
                table: "PlaceExtrasSets");

            migrationBuilder.DropIndex(
                name: "IX_PlaceExtrasSets_PlaceId",
                table: "PlaceExtrasSets");

            migrationBuilder.DropColumn(
                name: "Extra",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "RoomsNum",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "PlaceExtrasSets");

            migrationBuilder.AddColumn<int>(
                name: "BedroomsNum",
                table: "Places",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlaceExtrasSetId",
                table: "Places",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlaceForeignKey",
                table: "PlaceExtrasSets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Places_PlaceExtrasSetId",
                table: "Places",
                column: "PlaceExtrasSetId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Places_PlaceExtrasSets_PlaceExtrasSetId",
                table: "Places",
                column: "PlaceExtrasSetId",
                principalTable: "PlaceExtrasSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_PlaceExtrasSets_PlaceExtrasSetId",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_PlaceExtrasSetId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "BedroomsNum",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "PlaceExtrasSetId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "PlaceForeignKey",
                table: "PlaceExtrasSets");

            migrationBuilder.AddColumn<string>(
                name: "Extra",
                table: "Places",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomsNum",
                table: "Places",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "PlaceExtrasSets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PlaceExtrasSets_PlaceId",
                table: "PlaceExtrasSets",
                column: "PlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceExtrasSets_Places_PlaceId",
                table: "PlaceExtrasSets",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
