using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZepterTask.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NetPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrossPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLines_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sklep 1" },
                    { 2, "Sklep 2" },
                    { 3, "Sklep 3" },
                    { 4, "Sklep 4" },
                    { 5, "Sklep 5" },
                    { 6, "Sklep 6" },
                    { 7, "Sklep 7" },
                    { 8, "Sklep 8" },
                    { 9, "Sklep 9" },
                    { 10, "Sklep 10" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "PaymentMethod", "StoreId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 2, 3 },
                    { 3, 0, 4 },
                    { 4, 1, 5 },
                    { 5, 2, 6 },
                    { 6, 0, 7 },
                    { 7, 1, 8 },
                    { 8, 2, 9 },
                    { 9, 0, 10 },
                    { 10, 1, 1 },
                    { 11, 2, 2 },
                    { 12, 0, 3 },
                    { 13, 1, 4 },
                    { 14, 2, 5 },
                    { 15, 0, 6 },
                    { 16, 1, 7 },
                    { 17, 2, 8 },
                    { 18, 0, 9 },
                    { 19, 1, 10 },
                    { 20, 2, 1 },
                    { 21, 0, 2 },
                    { 22, 1, 3 },
                    { 23, 2, 4 },
                    { 24, 0, 5 },
                    { 25, 1, 6 },
                    { 26, 2, 7 },
                    { 27, 0, 8 },
                    { 28, 1, 9 },
                    { 29, 2, 10 },
                    { 30, 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "CustomerAddresses",
                columns: new[] { "Id", "City", "OrderId", "PostalCode", "Street" },
                values: new object[,]
                {
                    { 1, "Szczecin", 1, "00-01", "Street 1" },
                    { 2, "Poznan", 2, "00-02", "Street 2" },
                    { 3, "Katowice", 3, "00-03", "Street 3" },
                    { 4, "Wroclaw", 4, "00-04", "Street 4" },
                    { 5, "Bydgoszcz", 5, "00-05", "Street 5" },
                    { 6, "Gdansk", 6, "00-06", "Street 6" },
                    { 7, "Katowice", 7, "00-07", "Street 7" },
                    { 8, "Krakow", 8, "00-08", "Street 8" },
                    { 9, "Lublin", 9, "00-09", "Street 9" },
                    { 10, "Warsaw", 10, "00-010", "Street 10" },
                    { 11, "Bydgoszcz", 11, "00-011", "Street 11" },
                    { 12, "Gdansk", 12, "00-012", "Street 12" },
                    { 13, "Bydgoszcz", 13, "00-013", "Street 13" },
                    { 14, "Warsaw", 14, "00-014", "Street 14" },
                    { 15, "Lodz", 15, "00-015", "Street 15" },
                    { 16, "Poznan", 16, "00-016", "Street 16" },
                    { 17, "Katowice", 17, "00-017", "Street 17" },
                    { 18, "Krakow", 18, "00-018", "Street 18" },
                    { 19, "Lublin", 19, "00-019", "Street 19" },
                    { 20, "Poznan", 20, "00-020", "Street 20" },
                    { 21, "Szczecin", 21, "00-021", "Street 21" },
                    { 22, "Gdansk", 22, "00-022", "Street 22" },
                    { 23, "Szczecin", 23, "00-023", "Street 23" },
                    { 24, "Gdansk", 24, "00-024", "Street 24" },
                    { 25, "Lublin", 25, "00-025", "Street 25" },
                    { 26, "Wroclaw", 26, "00-026", "Street 26" },
                    { 27, "Lublin", 27, "00-027", "Street 27" },
                    { 28, "Gdansk", 28, "00-028", "Street 28" },
                    { 29, "Lublin", 29, "00-029", "Street 29" },
                    { 30, "Gdansk", 30, "00-030", "Street 30" }
                });

            migrationBuilder.InsertData(
                table: "OrderLines",
                columns: new[] { "Id", "GrossPrice", "NetPrice", "OrderId", "ProductCode", "Quantity" },
                values: new object[,]
                {
                    { 1, 141m, 131m, 1, "P1", 1 },
                    { 2, 142m, 132m, 2, "P2", 2 },
                    { 3, 143m, 133m, 3, "P3", 3 },
                    { 4, 144m, 134m, 4, "P4", 4 },
                    { 5, 145m, 135m, 5, "P5", 5 },
                    { 6, 146m, 136m, 6, "P6", 6 },
                    { 7, 147m, 137m, 7, "P7", 7 },
                    { 8, 148m, 138m, 8, "P8", 8 },
                    { 9, 149m, 139m, 9, "P9", 9 },
                    { 10, 150m, 140m, 10, "P10", 10 },
                    { 11, 151m, 141m, 11, "P11", 11 },
                    { 12, 152m, 142m, 12, "P12", 12 },
                    { 13, 153m, 143m, 13, "P13", 13 },
                    { 14, 154m, 144m, 14, "P14", 14 },
                    { 15, 155m, 145m, 15, "P15", 15 },
                    { 16, 156m, 146m, 16, "P16", 16 },
                    { 17, 157m, 147m, 17, "P17", 17 },
                    { 18, 158m, 148m, 18, "P18", 18 },
                    { 19, 159m, 149m, 19, "P19", 19 },
                    { 20, 160m, 150m, 20, "P20", 20 },
                    { 21, 161m, 151m, 21, "P21", 21 },
                    { 22, 162m, 152m, 22, "P22", 22 },
                    { 23, 163m, 153m, 23, "P23", 23 },
                    { 24, 164m, 154m, 24, "P24", 24 },
                    { 25, 165m, 155m, 25, "P25", 25 },
                    { 26, 166m, 156m, 26, "P26", 26 },
                    { 27, 167m, 157m, 27, "P27", 27 },
                    { 28, 168m, 158m, 28, "P28", 28 },
                    { 29, 169m, 159m, 29, "P29", 29 },
                    { 30, 170m, 160m, 30, "P30", 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_OrderId",
                table: "CustomerAddresses",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLines",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StoreId",
                table: "Orders",
                column: "StoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAddresses");

            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
