using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThreeSItSolution.Migrations
{
    public partial class Db3sItSolutionMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MContactUs",
                columns: table => new
                {
                    IID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CName = table.Column<string>(maxLength: 30, nullable: false),
                    CEmailId = table.Column<string>(maxLength: 30, nullable: false),
                    CSubject = table.Column<string>(maxLength: 30, nullable: false),
                    CMessage = table.Column<string>(maxLength: 8000, nullable: false),
                    DCreateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MContactUs", x => x.IID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MContactUs");
        }
    }
}
