using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingProject.Data.Migrations
{
    public partial class RemovePlaceExtraSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Extras_PlaceExtrasSets_PlaceExtrasSetId",
                table: "Extras");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_PlaceExtrasSets_PlaceExtrasSetId",
                table: "Places");

            migrationBuilder.DropTable(
                name: "PlaceExtrasSets");

            migrationBuilder.DropIndex(
                name: "IX_Places_PlaceExtrasSetId",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Extras_PlaceExtrasSetId",
                table: "Extras");

            migrationBuilder.DropColumn(
                name: "PlaceExtrasSetId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "PlaceExtrasSetId",
                table: "Extras");

            migrationBuilder.CreateTable(
                name: "PlaceExtras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    PlaceId = table.Column<int>(nullable: false),
                    ExtraId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceExtras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaceExtras_Extras_ExtraId",
                        column: x => x.ExtraId,
                        principalTable: "Extras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlaceExtras_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaceExtras_ExtraId",
                table: "PlaceExtras",
                column: "ExtraId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceExtras_IsDeleted",
                table: "PlaceExtras",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceExtras_PlaceId",
                table: "PlaceExtras",
                column: "PlaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaceExtras");

            migrationBuilder.AddColumn<int>(
                name: "PlaceExtrasSetId",
                table: "Places",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlaceExtrasSetId",
                table: "Extras",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlaceExtrasSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlaceForeignKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceExtrasSets", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Places_PlaceExtrasSetId",
                table: "Places",
                column: "PlaceExtrasSetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Extras_PlaceExtrasSetId",
                table: "Extras",
                column: "PlaceExtrasSetId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceExtrasSets_IsDeleted",
                table: "PlaceExtrasSets",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Extras_PlaceExtrasSets_PlaceExtrasSetId",
                table: "Extras",
                column: "PlaceExtrasSetId",
                principalTable: "PlaceExtrasSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Places_PlaceExtrasSets_PlaceExtrasSetId",
                table: "Places",
                column: "PlaceExtrasSetId",
                principalTable: "PlaceExtrasSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
