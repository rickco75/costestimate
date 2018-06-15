using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CostEstimate.Data.Migrations
{
    public partial class addedCabinetsAndTopsScaffold : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CabinetsAndTops",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CabinetsBaths = table.Column<double>(nullable: false),
                    CabinetsKitchen = table.Column<double>(nullable: false),
                    CounterTopBaths = table.Column<double>(nullable: false),
                    GraniteCounterTops = table.Column<double>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    WetBar = table.Column<double>(nullable: false),
                    WetBarCabinets = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabinetsAndTops", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CabinetsAndTops");
        }
    }
}
