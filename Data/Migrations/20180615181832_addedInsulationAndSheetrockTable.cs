using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CostEstimate.Data.Migrations
{
    public partial class addedInsulationAndSheetrockTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InsulationAndSheetrock",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FireCaulk = table.Column<double>(nullable: false),
                    Insulation = table.Column<double>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    RoofInsulation = table.Column<double>(nullable: false),
                    SheetrockAndFinish = table.Column<double>(nullable: false),
                    Soundproofing = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsulationAndSheetrock", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsulationAndSheetrock");
        }
    }
}
