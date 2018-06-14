using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CostEstimate.Data.Migrations
{
    public partial class addedClearingAndGradingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClearingAndGrading",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BasementGrade = table.Column<double>(nullable: false),
                    Culvert = table.Column<double>(nullable: false),
                    ErosControlMaterials = table.Column<double>(nullable: false),
                    ErosControlSubLabor = table.Column<double>(nullable: false),
                    GravelPadsAndFabric = table.Column<double>(nullable: false),
                    InitialWallsBackfill = table.Column<double>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    RoughGrade = table.Column<double>(nullable: false),
                    SepticSystem = table.Column<double>(nullable: false),
                    SurveyCost = table.Column<double>(nullable: false),
                    WaterLine = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClearingAndGrading", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClearingAndGrading");
        }
    }
}
