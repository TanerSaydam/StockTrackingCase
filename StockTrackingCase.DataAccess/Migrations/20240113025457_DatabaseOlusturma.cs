using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockTrackingCase.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseOlusturma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchasePrice = table.Column<decimal>(type: "money", nullable: false),
                    PurchasePriceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SellingPrice = table.Column<decimal>(type: "money", nullable: false),
                    SellingPriceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaperWeight = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockUnits_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Type",
                table: "Stocks",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockUnits_StockId",
                table: "StockUnits",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_StockUnits_UnitCode",
                table: "StockUnits",
                column: "UnitCode",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockUnits");

            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}
