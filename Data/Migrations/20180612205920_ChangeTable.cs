using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CostEstimate.Data.Migrations
{
    public partial class ChangeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BuildingPermites",
                table: "NonConstructionItems",
                newName: "BuildingPermits");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BuildingPermits",
                table: "NonConstructionItems",
                newName: "BuildingPermites");
        }
    }
}
