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
                    { 1, "City 1", 1, "00-01", "Street 1" },
                    { 2, "City 2", 2, "00-02", "Street 2" },
                    { 3, "City 3", 3, "00-03", "Street 3" },
                    { 4, "City 4", 4, "00-04", "Street 4" },
                    { 5, "City 5", 5, "00-05", "Street 5" },
                    { 6, "City 6", 6, "00-06", "Street 6" },
                    { 7, "City 7", 7, "00-07", "Street 7" },
                    { 8, "City 8", 8, "00-08", "Street 8" },
                    { 9, "City 9", 9, "00-09", "Street 9" },
                    { 10, "City 10", 10, "00-010", "Street 10" },
                    { 11, "City 11", 11, "00-011", "Street 11" },
                    { 12, "City 12", 12, "00-012", "Street 12" },
                    { 13, "City 13", 13, "00-013", "Street 13" },
                    { 14, "City 14", 14, "00-014", "Street 14" },
                    { 15, "City 15", 15, "00-015", "Street 15" },
                    { 16, "City 16", 16, "00-016", "Street 16" },
                    { 17, "City 17", 17, "00-017", "Street 17" },
                    { 18, "City 18", 18, "00-018", "Street 18" },
                    { 19, "City 19", 19, "00-019", "Street 19" },
                    { 20, "City 20", 20, "00-020", "Street 20" },
                    { 21, "City 21", 21, "00-021", "Street 21" },
                    { 22, "City 22", 22, "00-022", "Street 22" },
                    { 23, "City 23", 23, "00-023", "Street 23" },
                    { 24, "City 24", 24, "00-024", "Street 24" },
                    { 25, "City 25", 25, "00-025", "Street 25" },
                    { 26, "City 26", 26, "00-026", "Street 26" },
                    { 27, "City 27", 27, "00-027", "Street 27" },
                    { 28, "City 28", 28, "00-028", "Street 28" },
                    { 29, "City 29", 29, "00-029", "Street 29" },
                    { 30, "City 30", 30, "00-030", "Street 30" }
                });

            migrationBuilder.InsertData(
                table: "OrderLines",
                columns: new[] { "Id", "GrossPrice", "NetPrice", "OrderId", "ProductCode", "Quantity" },
                values: new object[,]
                {
                    { 1, 121m, 101m, 1, "P1", 1 },
                    { 2, 122m, 102m, 2, "P2", 2 },
                    { 3, 123m, 103m, 3, "P3", 3 },
                    { 4, 124m, 104m, 4, "P4", 4 },
                    { 5, 125m, 105m, 5, "P5", 5 },
                    { 6, 126m, 106m, 6, "P6", 6 },
                    { 7, 127m, 107m, 7, "P7", 7 },
                    { 8, 128m, 108m, 8, "P8", 8 },
                    { 9, 129m, 109m, 9, "P9", 9 },
                    { 10, 130m, 110m, 10, "P10", 10 },
                    { 11, 131m, 111m, 11, "P11", 11 },
                    { 12, 132m, 112m, 12, "P12", 12 },
                    { 13, 133m, 113m, 13, "P13", 13 },
                    { 14, 134m, 114m, 14, "P14", 14 },
                    { 15, 135m, 115m, 15, "P15", 15 },
                    { 16, 136m, 116m, 16, "P16", 16 },
                    { 17, 137m, 117m, 17, "P17", 17 },
                    { 18, 138m, 118m, 18, "P18", 18 },
                    { 19, 139m, 119m, 19, "P19", 19 },
                    { 20, 140m, 120m, 20, "P20", 20 },
                    { 21, 141m, 121m, 21, "P21", 21 },
                    { 22, 142m, 122m, 22, "P22", 22 },
                    { 23, 143m, 123m, 23, "P23", 23 },
                    { 24, 144m, 124m, 24, "P24", 24 },
                    { 25, 145m, 125m, 25, "P25", 25 },
                    { 26, 146m, 126m, 26, "P26", 26 },
                    { 27, 147m, 127m, 27, "P27", 27 },
                    { 28, 148m, 128m, 28, "P28", 28 },
                    { 29, 149m, 129m, 29, "P29", 29 },
                    { 30, 150m, 130m, 30, "P30", 30 }
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
