using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CostEstimate.Data.Migrations
{
    public partial class droppedForeignKeyNonConstructionItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NonConstructionItems_Projects_ProjectId",
                table: "NonConstructionItems");

            migrationBuilder.DropIndex(
                name: "IX_NonConstructionItems_ProjectId",
                table: "NonConstructionItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_NonConstructionItems_ProjectId",
                table: "NonConstructionItems",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_NonConstructionItems_Projects_ProjectId",
                table: "NonConstructionItems",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
