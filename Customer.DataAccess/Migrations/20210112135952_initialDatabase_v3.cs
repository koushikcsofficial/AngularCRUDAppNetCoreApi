using Microsoft.EntityFrameworkCore.Migrations;

namespace Customer.DataAccess.Migrations
{
    public partial class initialDatabase_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerPostalCode",
                table: "Customers",
                newName: "customerPostalCode");

            migrationBuilder.RenameColumn(
                name: "CustomerMobileNumber",
                table: "Customers",
                newName: "customerMobileNumber");

            migrationBuilder.RenameColumn(
                name: "CustomerLastName",
                table: "Customers",
                newName: "customerLastName");

            migrationBuilder.RenameColumn(
                name: "CustomerFirstName",
                table: "Customers",
                newName: "customerFirstName");

            migrationBuilder.RenameColumn(
                name: "CustomerEmail",
                table: "Customers",
                newName: "customerEmail");

            migrationBuilder.RenameColumn(
                name: "CustomerAddress",
                table: "Customers",
                newName: "customerAddress");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Customers",
                newName: "customerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "customerPostalCode",
                table: "Customers",
                newName: "CustomerPostalCode");

            migrationBuilder.RenameColumn(
                name: "customerMobileNumber",
                table: "Customers",
                newName: "CustomerMobileNumber");

            migrationBuilder.RenameColumn(
                name: "customerLastName",
                table: "Customers",
                newName: "CustomerLastName");

            migrationBuilder.RenameColumn(
                name: "customerFirstName",
                table: "Customers",
                newName: "CustomerFirstName");

            migrationBuilder.RenameColumn(
                name: "customerEmail",
                table: "Customers",
                newName: "CustomerEmail");

            migrationBuilder.RenameColumn(
                name: "customerAddress",
                table: "Customers",
                newName: "CustomerAddress");

            migrationBuilder.RenameColumn(
                name: "customerId",
                table: "Customers",
                newName: "CustomerId");
        }
    }
}
