using Microsoft.EntityFrameworkCore.Migrations;

namespace Customer.DataAccess.Migrations
{
    public partial class initialDatabase_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Customeraddress",
                table: "Customers",
                newName: "CustomerAddress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerAddress",
                table: "Customers",
                newName: "Customeraddress");
        }
    }
}
