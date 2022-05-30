using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RevisionTwo_App.Migrations
{
    public partial class fixed_Date_Cases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "CRCases",
                newName: "DateReported");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateReported",
                table: "CRCases",
                newName: "Date");
        }
    }
}
