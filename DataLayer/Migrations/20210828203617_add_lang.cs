using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class add_lang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Langs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Langs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    LangId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Banners_Langs_LangId",
                        column: x => x.LangId,
                        principalTable: "Langs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImagesOfOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVideo = table.Column<bool>(type: "bit", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagesOfOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagesOfOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPopular = table.Column<bool>(type: "bit", nullable: false),
                    IsNew = table.Column<bool>(type: "bit", nullable: false),
                    IsSale = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSizes",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSizes", x => new { x.ProductId, x.SizeId });
                    table.ForeignKey(
                        name: "FK_ProductSizes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSizes_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Nike" },
                    { 2, "Adidas" }
                });

            migrationBuilder.InsertData(
                table: "Langs",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "en" },
                    { 2, "ru" },
                    { 3, "lv" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                column: "Id",
                values: new object[]
                {
                    1,
                    2
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Path" },
                values: new object[,]
                {
                    { 1, "https://sun9-29.userapi.com/impg/KKIKOAbrbxQ10r-leSVK6kuxNhGrT3KhwHQFHg/Em8-Ra9S0Ig.jpg?size=738x1600&quality=96&sign=f9793e2fc7b1bc0716d01f0b1038a4c9&type=album" },
                    { 2, "https://sun9-50.userapi.com/impg/QtYSdIRo6HjuGGXPwPXXUVHOdx1ioTc9LPdsDw/WnLfiUqHT5Y.jpg?size=738x1600&quality=96&sign=256f1d05f3c25c87a607c1869fe5eda7&type=album" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 11, "EUR 46" },
                    { 10, "EUR 45" },
                    { 9, "EUR 44" },
                    { 8, "EUR 43" },
                    { 7, "EUR 42" },
                    { 2, "EUR 37" },
                    { 5, "EUR 40" },
                    { 4, "EUR 39" },
                    { 3, "EUR 38" },
                    { 12, "EUR 47" },
                    { 1, "EUR 36" },
                    { 6, "EUR 41" },
                    { 13, "EUR 48" }
                });

            migrationBuilder.InsertData(
                table: "Banners",
                columns: new[] { "Id", "LangId", "Order", "Path" },
                values: new object[,]
                {
                    { 1, 1, 3, "https://sun2.megafon-nn.userapi.com/impg/I1FMk1QP3-5AKjE2tIz7WXpzAP7CFf2dRPpadg/tKy87HiLsCQ.jpg?size=825x350&quality=96&sign=4c339bff3d2c2a57d5d1c18bc0fff836&type=album" },
                    { 2, 1, 2, "https://sun9-76.userapi.com/impg/rHgrE4QUq72s_vr2iG44Ds6Y5uK6ZpUrFEVg-A/a8FZaxsEnwg.jpg?size=825x350&quality=96&sign=214e12be2bea072d961169a42b1d5022&type=album" },
                    { 3, 1, 1, "https://sun9-31.userapi.com/impg/nNE3Z4Dn-r3--b7G4sZqNvwSU5jzBxNNxg_XJA/WkIwtqBE9r0.jpg?size=825x350&quality=96&sign=e9b0d055db91b7936f364e62da99b569&type=album" }
                });

            migrationBuilder.InsertData(
                table: "ImagesOfOrder",
                columns: new[] { "Id", "IsVideo", "OrderId", "Path" },
                values: new object[,]
                {
                    { 1, false, 1, "https://sun9-54.userapi.com/impg/JLpJr7cUWS6bCnNVYCW3SprZuCgPg1RTXiXhAg/V0Y-Nv518mY.jpg?size=255x255&quality=96&sign=6f2419d7cbde4448f6d47875e431d918&type=album" },
                    { 2, false, 1, "https://sun9-65.userapi.com/impg/2oNBWX3eqqEZ-o9Hh1HSViKyat8mHpAXBqVt0Q/IIba8yAhB4w.jpg?size=255x255&quality=96&sign=2cc1025050face68687b16b92a5efedf&type=album" },
                    { 3, false, 1, "https://sun9-11.userapi.com/impg/86sOSCeIWARW-BcX901uyA2Ob8_Wr0lfTC_WeA/xTSPOHIb6Hg.jpg?size=255x255&quality=96&sign=54f21ebc92f37effa881f973758fd95f&type=album" },
                    { 4, true, 1, "https://sun9-54.userapi.com/impg/JLpJr7cUWS6bCnNVYCW3SprZuCgPg1RTXiXhAg/V0Y-Nv518mY.jpg?size=255x255&quality=96&sign=6f2419d7cbde4448f6d47875e431d918&type=album" },
                    { 5, false, 2, "https://sun9-54.userapi.com/impg/JLpJr7cUWS6bCnNVYCW3SprZuCgPg1RTXiXhAg/V0Y-Nv518mY.jpg?size=255x255&quality=96&sign=6f2419d7cbde4448f6d47875e431d918&type=album" },
                    { 6, false, 2, "https://sun9-54.userapi.com/impg/JLpJr7cUWS6bCnNVYCW3SprZuCgPg1RTXiXhAg/V0Y-Nv518mY.jpg?size=255x255&quality=96&sign=6f2419d7cbde4448f6d47875e431d918&type=album" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Nike Air Force" },
                    { 2, 1, "Nike Jordan" },
                    { 3, 2, "Adidas Ozweego" },
                    { 4, 2, "Adidas ZX" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "DateCreate", "Discount", "IsNew", "IsPopular", "IsSale", "ModelId", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 5, 9, 7, 24, 48, 278, DateTimeKind.Local).AddTicks(3473), 200m, true, true, false, 1, 250m, "Nike Air Force 1" },
                    { 2, 1, new DateTime(2021, 5, 9, 7, 25, 48, 278, DateTimeKind.Local).AddTicks(3473), 0m, false, true, false, 2, 300m, "Nike Jordan 1 Low" },
                    { 3, 2, new DateTime(2021, 5, 9, 7, 26, 48, 278, DateTimeKind.Local).AddTicks(3473), 0m, true, false, false, 3, 500m, "Adidas Ozweego Pride" },
                    { 4, 2, new DateTime(2021, 5, 9, 7, 27, 48, 278, DateTimeKind.Local).AddTicks(3473), 0m, false, false, false, 4, 150m, "Adidas ZX 750" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Path", "ProductId" },
                values: new object[,]
                {
                    { 1, "https://sun9-54.userapi.com/impg/JLpJr7cUWS6bCnNVYCW3SprZuCgPg1RTXiXhAg/V0Y-Nv518mY.jpg?size=255x255&quality=96&sign=6f2419d7cbde4448f6d47875e431d918&type=album", 1 },
                    { 2, "https://sun9-11.userapi.com/impg/86sOSCeIWARW-BcX901uyA2Ob8_Wr0lfTC_WeA/xTSPOHIb6Hg.jpg?size=255x255&quality=96&sign=54f21ebc92f37effa881f973758fd95f&type=album", 1 },
                    { 3, "https://sun9-65.userapi.com/impg/2oNBWX3eqqEZ-o9Hh1HSViKyat8mHpAXBqVt0Q/IIba8yAhB4w.jpg?size=255x255&quality=96&sign=2cc1025050face68687b16b92a5efedf&type=album", 1 },
                    { 4, "https://sun9-65.userapi.com/impg/2oNBWX3eqqEZ-o9Hh1HSViKyat8mHpAXBqVt0Q/IIba8yAhB4w.jpg?size=255x255&quality=96&sign=2cc1025050face68687b16b92a5efedf&type=album", 2 },
                    { 5, "https://sun9-54.userapi.com/impg/JLpJr7cUWS6bCnNVYCW3SprZuCgPg1RTXiXhAg/V0Y-Nv518mY.jpg?size=255x255&quality=96&sign=6f2419d7cbde4448f6d47875e431d918&type=album", 2 },
                    { 7, "https://sun9-65.userapi.com/impg/2oNBWX3eqqEZ-o9Hh1HSViKyat8mHpAXBqVt0Q/IIba8yAhB4w.jpg?size=255x255&quality=96&sign=2cc1025050face68687b16b92a5efedf&type=album", 4 },
                    { 6, "https://sun9-11.userapi.com/impg/86sOSCeIWARW-BcX901uyA2Ob8_Wr0lfTC_WeA/xTSPOHIb6Hg.jpg?size=255x255&quality=96&sign=54f21ebc92f37effa881f973758fd95f&type=album", 3 }
                });

            migrationBuilder.InsertData(
                table: "ProductSizes",
                columns: new[] { "ProductId", "SizeId" },
                values: new object[,]
                {
                    { 3, 7 },
                    { 3, 6 },
                    { 3, 5 },
                    { 3, 4 },
                    { 3, 3 },
                    { 2, 5 },
                    { 2, 10 },
                    { 1, 9 },
                    { 1, 8 },
                    { 1, 7 },
                    { 1, 6 },
                    { 3, 2 },
                    { 4, 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Banners_LangId",
                table: "Banners",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagesOfOrder_OrderId",
                table: "ImagesOfOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandId",
                table: "Models",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ModelId",
                table: "Products",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizes_SizeId",
                table: "ProductSizes",
                column: "SizeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banners");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "ImagesOfOrder");

            migrationBuilder.DropTable(
                name: "ProductSizes");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Langs");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
