using JPFigure.Entities.Enums;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JPFigure.Migrations
{
    public partial class UpdateFiguresSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.AlterDatabase()
				.Annotation("Npgsql:Enum:figure_scale", "one_twelveth,one_tenth,one_eight,one_seventh,one_sixth,one_fifth,one_fourth,one_third,non_scale")
				.Annotation("Npgsql:Enum:gundam_type", "super_deformed,high_grade,real_grade,master_grade,perfect_grade,non_gundam")
				.OldAnnotation("Npgsql:Enum:figure_scale", "one_twelveth,one_tenth,one_eight,one_seventh,one_sixth,one_fifth,one_fourth,one_third,non_scale");

			migrationBuilder.AddColumn<GundamType>(
                name: "GundamType",
                table: "Figures",
                type: "gundam_type",
                nullable: false,
                defaultValue: GundamType.SuperDeformed);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GundamType",
                table: "Figures");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:figure_scale", "one_twelveth,one_tenth,one_eight,one_seventh,one_sixth,one_fifth,one_fourth,one_third,non_scale")
                .Annotation("Npgsql:Enum:figure_type", "scale_figure,nendoroid,pop_up_parade,figma,others")
                .OldAnnotation("Npgsql:Enum:figure_scale", "one_twelveth,one_tenth,one_eight,one_seventh,one_sixth,one_fifth,one_fourth,one_third,non_scale")
                .OldAnnotation("Npgsql:Enum:figure_type", "scale_figure,nendoroid,gundam,others")
                .OldAnnotation("Npgsql:Enum:gundam_type", "super_deformed,high_grade,real_grade,master_grade,perfect_grade,non_gundam");
        }
    }
}
