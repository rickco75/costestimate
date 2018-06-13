using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CostEstimate.Data.Migrations
{
    public partial class AddedNonConstructionItemsWithForeignKey2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NonConstructionItems_Projects_ProjectForeignKey",
                table: "NonConstructionItems");

            migrationBuilder.DropIndex(
                name: "IX_NonConstructionItems_ProjectForeignKey",
                table: "NonConstructionItems");

            migrationBuilder.DropColumn(
                name: "ProjectForeignKey",
                table: "NonConstructionItems");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NonConstructionItems_Projects_ProjectId",
                table: "NonConstructionItems");

            migrationBuilder.DropIndex(
                name: "IX_NonConstructionItems_ProjectId",
                table: "NonConstructionItems");

            migrationBuilder.AddColumn<int>(
                name: "ProjectForeignKey",
                table: "NonConstructionItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NonConstructionItems_ProjectForeignKey",
                table: "NonConstructionItems",
                column: "ProjectForeignKey");

            migrationBuilder.AddForeignKey(
                name: "FK_NonConstructionItems_Projects_ProjectForeignKey",
                table: "NonConstructionItems",
                column: "ProjectForeignKey",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
