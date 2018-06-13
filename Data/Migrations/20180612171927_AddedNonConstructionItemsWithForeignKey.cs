using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CostEstimate.Data.Migrations
{
    public partial class AddedNonConstructionItemsWithForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NonConstructionItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArchitectPlans = table.Column<double>(nullable: false),
                    AttorneyFee = table.Column<double>(nullable: false),
                    BuildersLiabilityInsurances = table.Column<double>(nullable: false),
                    BuildersRiskInsurances = table.Column<double>(nullable: false),
                    BuildersWorkmanCompIns = table.Column<double>(nullable: false),
                    BuildingPermites = table.Column<double>(nullable: false),
                    ConstructionLoanFee = table.Column<double>(nullable: false),
                    ConstructionLoanInterest = table.Column<double>(nullable: false),
                    InspectionFeesAndCO = table.Column<double>(nullable: false),
                    Misc = table.Column<double>(nullable: false),
                    ProjectForeignKey = table.Column<int>(nullable: true),
                    ProjectId = table.Column<int>(nullable: false),
                    PropertyTaxes = table.Column<double>(nullable: false),
                    TempElectricServiceMeter = table.Column<double>(nullable: false),
                    WarrantyServices = table.Column<double>(nullable: false),
                    WaterMeter = table.Column<double>(nullable: false),
                    WorkmansCompInsurances = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonConstructionItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NonConstructionItems_Projects_ProjectForeignKey",
                        column: x => x.ProjectForeignKey,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NonConstructionItems_ProjectForeignKey",
                table: "NonConstructionItems",
                column: "ProjectForeignKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NonConstructionItems");
        }
    }
}
