using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CostEstimate.Data.Migrations
{
    public partial class addedFoundationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foundation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdditionalSlabAsNeeded = table.Column<double>(nullable: false),
                    AdditionalWallAsNeeded = table.Column<double>(nullable: false),
                    ConcreteForSlab = table.Column<double>(nullable: false),
                    ConcreteForWallAndFooting = table.Column<double>(nullable: false),
                    ConcretePumpAsNeeded = table.Column<double>(nullable: false),
                    FootingWallFormMaterial = table.Column<double>(nullable: false),
                    FormMaterialSlab = table.Column<double>(nullable: false),
                    LaborForWallAndFooting = table.Column<double>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    TermiteTreatment = table.Column<double>(nullable: false),
                    Waterproofing = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foundation", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foundation");
        }
    }
}
