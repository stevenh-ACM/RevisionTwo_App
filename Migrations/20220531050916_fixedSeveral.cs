using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RevisionTwo_App.Migrations
{
    public partial class fixedSeveral : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "Shipments",
                newName: "LastModifiedDateTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModifiedDateTime",
                table: "Shipments",
                newName: "LastModified");
        }
    }
}
