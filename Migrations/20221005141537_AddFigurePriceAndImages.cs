using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JPFigure.Migrations
{
    public partial class AddFigurePriceAndImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string[]>(
                name: "Images",
                table: "Figures",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Figures",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Images",
                table: "Figures");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Figures");
        }
    }
}
