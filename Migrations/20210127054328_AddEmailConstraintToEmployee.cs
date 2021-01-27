using Microsoft.EntityFrameworkCore.Migrations;

namespace EjadaCompany.Migrations
{
    public partial class AddEmailConstraintToEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Employee",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employee",
                newName: "ID");
        }
    }
}
