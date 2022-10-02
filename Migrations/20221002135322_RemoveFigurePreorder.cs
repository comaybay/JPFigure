using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JPFigure.Migrations
{
    public partial class RemoveFigurePreorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPreorder",
                table: "Figures");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPreorder",
                table: "Figures",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
