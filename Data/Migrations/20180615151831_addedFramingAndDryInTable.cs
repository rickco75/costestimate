using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CostEstimate.Data.Migrations
{
    public partial class addedFramingAndDryInTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FramingAndDryIn",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdditionalDecks = table.Column<double>(nullable: false),
                    CoveredDecks = table.Column<double>(nullable: false),
                    CoveredDecksLabor = table.Column<double>(nullable: false),
                    ExteriorDeckBalusters = table.Column<double>(nullable: false),
                    ExteriorDeckLabor = table.Column<double>(nullable: false),
                    ExteriorDeckMaterial = table.Column<double>(nullable: false),
                    ExteriorDoors = table.Column<double>(nullable: false),
                    FirePlaces = table.Column<double>(nullable: false),
                    FramingLabor = table.Column<double>(nullable: false),
                    FramingMaterial = table.Column<double>(nullable: false),
                    FrontDoor = table.Column<double>(nullable: false),
                    FrontPorch = table.Column<double>(nullable: false),
                    GarageDoor = table.Column<double>(nullable: false),
                    NailAndMisc = table.Column<double>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    RoofLabor = table.Column<double>(nullable: false),
                    RoofMaterialShingle = table.Column<double>(nullable: false),
                    SlidingLabor = table.Column<double>(nullable: false),
                    SlidingMaterial = table.Column<double>(nullable: false),
                    StoneVeneer = table.Column<double>(nullable: false),
                    WindowsSliders = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FramingAndDryIn", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FramingAndDryIn");
        }
    }
}
