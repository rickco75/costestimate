using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CostEstimate.Data.Migrations
{
    public partial class costModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CostModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AveragePerSqFootFinsihed = table.Column<double>(nullable: false),
                    AvgCostGarage = table.Column<double>(nullable: false),
                    AvgCostMainLevel = table.Column<double>(nullable: false),
                    AvgCostUnfinsihedBasement = table.Column<double>(nullable: false),
                    AvgCostUpperLoft = table.Column<double>(nullable: false),
                    AvgPerSqFtFinBasement = table.Column<double>(nullable: false),
                    BasementUnfinishedSqFeet = table.Column<double>(nullable: false),
                    FinishedBasement = table.Column<double>(nullable: false),
                    Garage = table.Column<double>(nullable: false),
                    MainLevelSquareFeet = table.Column<double>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    TotalSquareFtHouse = table.Column<double>(nullable: false),
                    TotalSquareFtUnderRoof = table.Column<double>(nullable: false),
                    UpperLevelLoft = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CostModel");
        }
    }
}
