using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiGear.Migrations
{
    public partial class cambioint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PurchasePrice",
                table: "purchaseDetails",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(7, 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PurchasePrice",
                table: "purchaseDetails",
                type: "decimal(7, 2)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
