using System;
using JPFigure.Entities.Enums;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JPFigure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:figure_scale", "one_twelveth,one_tenth,one_eight,one_seventh,one_sixth,one_fifth,one_fourth,one_third,non_scale")
                .Annotation("Npgsql:Enum:figure_type", "scale_figure,nendoroid,pop_up_parade,figma,others");

            migrationBuilder.CreateTable(
                name: "Manufactures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufactures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SeriesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Figures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsPreorder = table.Column<bool>(type: "boolean", nullable: false),
                    StockCount = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<FigureType>(type: "figure_type", nullable: false),
                    ProductName = table.Column<string>(type: "text", nullable: false),
                    CharacterId = table.Column<int>(type: "integer", nullable: false),
                    ManufactureId = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Scale = table.Column<FigureScale>(type: "figure_scale", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Figures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Figures_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Figures_Manufactures_ManufactureId",
                        column: x => x.ManufactureId,
                        principalTable: "Manufactures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_SeriesId",
                table: "Characters",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Figures_CharacterId",
                table: "Figures",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Figures_ManufactureId",
                table: "Figures",
                column: "ManufactureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Figures");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Manufactures");

            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
