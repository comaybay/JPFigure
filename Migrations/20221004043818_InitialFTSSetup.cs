using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

#nullable disable

namespace JPFigure.Migrations
{
    public partial class InitialFTSSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:CollationDefinition:nondeterministic", "vi-VN,vi-VN,icu,False")
                .Annotation("Npgsql:Enum:figure_scale", "one_twelveth,one_tenth,one_eight,one_seventh,one_sixth,one_fifth,one_fourth,one_third,non_scale")
                .Annotation("Npgsql:Enum:figure_type", "scale_figure,nendoroid,gundam,others")
                .Annotation("Npgsql:Enum:gundam_type", "super_deformed,high_grade,real_grade,master_grade,perfect_grade,non_gundam")
                .OldAnnotation("Npgsql:Enum:figure_scale", "one_twelveth,one_tenth,one_eight,one_seventh,one_sixth,one_fifth,one_fourth,one_third,non_scale")
                .OldAnnotation("Npgsql:Enum:figure_type", "scale_figure,nendoroid,gundam,others")
                .OldAnnotation("Npgsql:Enum:gundam_type", "super_deformed,high_grade,real_grade,master_grade,perfect_grade,non_gundam");

            migrationBuilder.AddColumn<NpgsqlTsVector>(
                name: "SearchVector",
                table: "Figures",
                type: "tsvector",
                nullable: false,
                collation: "nondeterministic");

            migrationBuilder.CreateIndex(
                name: "IX_Figures_SearchVector",
                table: "Figures",
                column: "SearchVector")
                .Annotation("Npgsql:IndexMethod", "GIN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Figures_SearchVector",
                table: "Figures");

            migrationBuilder.DropColumn(
                name: "SearchVector",
                table: "Figures");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:figure_scale", "one_twelveth,one_tenth,one_eight,one_seventh,one_sixth,one_fifth,one_fourth,one_third,non_scale")
                .Annotation("Npgsql:Enum:figure_type", "scale_figure,nendoroid,gundam,others")
                .Annotation("Npgsql:Enum:gundam_type", "super_deformed,high_grade,real_grade,master_grade,perfect_grade,non_gundam")
                .OldAnnotation("Npgsql:CollationDefinition:nondeterministic", "vi-VN,vi-VN,icu,False")
                .OldAnnotation("Npgsql:Enum:figure_scale", "one_twelveth,one_tenth,one_eight,one_seventh,one_sixth,one_fifth,one_fourth,one_third,non_scale")
                .OldAnnotation("Npgsql:Enum:figure_type", "scale_figure,nendoroid,gundam,others")
                .OldAnnotation("Npgsql:Enum:gundam_type", "super_deformed,high_grade,real_grade,master_grade,perfect_grade,non_gundam");
        }
    }
}
