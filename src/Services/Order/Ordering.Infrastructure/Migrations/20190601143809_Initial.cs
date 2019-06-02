using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ordering.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OBOP_ORDER",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ACCOUNT_ID = table.Column<long>(nullable: false),
                    NUMBER = table.Column<string>(nullable: true),
                    REVISION_NO = table.Column<int>(nullable: false),
                    TIME = table.Column<DateTime>(type: "datetime", nullable: false),
                    ORDER_TYPE_ID = table.Column<long>(nullable: false),
                    ON_HOLD = table.Column<bool>(nullable: true),
                    ORDER_QUANTITY = table.Column<int>(nullable: true),
                    PLANNED_SHIPMENT_TIME = table.Column<DateTime>(type: "datetime", nullable: true),
                    PLANNED_DELIVERY_TIME = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OBOP_ORDER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OBOP_ORDER_DETAIL",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ORDER_ID = table.Column<long>(nullable: false),
                    LINE_NUMBER = table.Column<string>(nullable: true),
                    ITEM_MASTER_ID = table.Column<long>(nullable: false),
                    QUANTITY = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OBOP_ORDER_DETAIL", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OBOP_ORDER_DETAIL_OBOP_ORDER_ORDER_ID",
                        column: x => x.ORDER_ID,
                        principalTable: "OBOP_ORDER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OBOP_ORDER_DETAIL_ORDER_ID",
                table: "OBOP_ORDER_DETAIL",
                column: "ORDER_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OBOP_ORDER_DETAIL");

            migrationBuilder.DropTable(
                name: "OBOP_ORDER");
        }
    }
}
