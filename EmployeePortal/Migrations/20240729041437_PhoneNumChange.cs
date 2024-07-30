using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeePortal.Migrations
{
    /// <inheritdoc />
    public partial class PhoneNumChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Remove the Salary column if exists
            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Employees");

            // Rename the Salary column to PhoneNo (if you renamed it from Salary)
            migrationBuilder.RenameColumn(
                name: "Salary",
                table: "Employees",
                newName: "PhoneNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        { // Revert the changes
            migrationBuilder.RenameColumn(
                name: "PhoneNo",
                table: "Employees",
                newName: "Salary");

            migrationBuilder.AddColumn<string>(
                name: "Salary",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

        }
    }
}
