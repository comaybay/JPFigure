using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JPFigure.Migrations
{
    public partial class AddRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:figure_scale", "one_twelveth,one_tenth,one_eight,one_seventh,one_sixth,one_fifth,one_fourth,one_third,non_scale")
                .Annotation("Npgsql:Enum:figure_type", "scale_figure,nendoroid,others,gundam,gundam2")
                .Annotation("Npgsql:Enum:gundam_type", "super_deformed,high_grade,real_grade,master_grade,perfect_grade,non_gundam")
                .OldAnnotation("Npgsql:Enum:figure_scale", "one_twelveth,one_tenth,one_eight,one_seventh,one_sixth,one_fifth,one_fourth,one_third,non_scale")
                .OldAnnotation("Npgsql:Enum:figure_type", "scale_figure,nendoroid,others,gundam")
                .OldAnnotation("Npgsql:Enum:gundam_type", "super_deformed,high_grade,real_grade,master_grade,perfect_grade,non_gundam");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    IsFemale = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateOfBirth", "Email", "IsFemale", "Name", "Password", "Role" },
                values: new object[] { 1, null, "admin@gmail.com", null, "Admin", "admin", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:figure_scale", "one_twelveth,one_tenth,one_eight,one_seventh,one_sixth,one_fifth,one_fourth,one_third,non_scale")
                .Annotation("Npgsql:Enum:figure_type", "scale_figure,nendoroid,others,gundam")
                .Annotation("Npgsql:Enum:gundam_type", "super_deformed,high_grade,real_grade,master_grade,perfect_grade,non_gundam")
                .OldAnnotation("Npgsql:Enum:figure_scale", "one_twelveth,one_tenth,one_eight,one_seventh,one_sixth,one_fifth,one_fourth,one_third,non_scale")
                .OldAnnotation("Npgsql:Enum:figure_type", "scale_figure,nendoroid,others,gundam,gundam2")
                .OldAnnotation("Npgsql:Enum:gundam_type", "super_deformed,high_grade,real_grade,master_grade,perfect_grade,non_gundam");
        }
    }
}
