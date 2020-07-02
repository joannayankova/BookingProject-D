using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingProject.Data.Migrations
{
    public partial class ModelsUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Reviews",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Reviews",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Regions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Regions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "PlaceExtrasSets",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PlaceExtrasSets",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Extras",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Extras",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_IsDeleted",
                table: "Reviews",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_IsDeleted",
                table: "Regions",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceExtrasSets_IsDeleted",
                table: "PlaceExtrasSets",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Extras_IsDeleted",
                table: "Extras",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reviews_IsDeleted",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Regions_IsDeleted",
                table: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_PlaceExtrasSets_IsDeleted",
                table: "PlaceExtrasSets");

            migrationBuilder.DropIndex(
                name: "IX_Extras_IsDeleted",
                table: "Extras");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "PlaceExtrasSets");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PlaceExtrasSets");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Extras");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Extras");
        }
    }
}
