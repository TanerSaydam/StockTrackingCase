using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockTrackingCase.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class StockUnitTablosundaAlanIsimleriDegistirildi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SellingPriceType",
                table: "StockUnits",
                newName: "SellingPriceCurrency");

            migrationBuilder.RenameColumn(
                name: "PurchasePriceType",
                table: "StockUnits",
                newName: "PurchasePriceCurrency");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SellingPriceCurrency",
                table: "StockUnits",
                newName: "SellingPriceType");

            migrationBuilder.RenameColumn(
                name: "PurchasePriceCurrency",
                table: "StockUnits",
                newName: "PurchasePriceType");
        }
    }
}
