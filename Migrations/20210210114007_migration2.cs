using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaOrderingApp.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblPizza",
                keyColumn: "serialNo",
                keyValue: 1,
                column: "Image",
                value: "/barbecueChickenPizza.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TblPizza",
                keyColumn: "serialNo",
                keyValue: 1,
                column: "Image",
                value: "/barbequeChickenPizza.jpg");
        }
    }
}
