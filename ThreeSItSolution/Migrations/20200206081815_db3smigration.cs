using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThreeSItSolution.Migrations
{
    public partial class db3smigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CSubject",
                table: "MContactUs",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "CName",
                table: "MContactUs",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "CMessage",
                table: "MContactUs",
                maxLength: 8000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 8000);

            migrationBuilder.AlterColumn<string>(
                name: "CEmailId",
                table: "MContactUs",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 30);

            migrationBuilder.CreateTable(
                name: "MEnquiry",
                columns: table => new
                {
                    IID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cFullName = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    cAddress = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false),
                    cMobileNo = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    cPhoneNo = table.Column<string>(type: "VARCHAR(30)", nullable: true),
                    cEmailId = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    dDob = table.Column<DateTime>(type: "DateTime", nullable: false),
                    cGenger = table.Column<string>(type: "VARCHAR(1)", maxLength: 1, nullable: false),
                    cGuradian = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    cCompnay = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: true),
                    cAcademic = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    cCareerBackground = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    cCurrentOccupation = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    cSchaool = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    cReason = table.Column<string>(type: "VARCHAR(2000)", maxLength: 2000, nullable: false),
                    cSourceOfInfo = table.Column<string>(type: "VARCHAR(1000)", maxLength: 1000, nullable: false),
                    cRemakrs = table.Column<string>(type: "VARCHAR(1000)", maxLength: 1000, nullable: true),
                    DCreateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEnquiry", x => x.IID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MEnquiry");

            migrationBuilder.AlterColumn<string>(
                name: "CSubject",
                table: "MContactUs",
                type: "varchar(1000)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "CName",
                table: "MContactUs",
                type: "varchar(50)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "CMessage",
                table: "MContactUs",
                type: "varchar(1000)",
                maxLength: 8000,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 8000);

            migrationBuilder.AlterColumn<string>(
                name: "CEmailId",
                table: "MContactUs",
                type: "varchar(50)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }
    }
}
