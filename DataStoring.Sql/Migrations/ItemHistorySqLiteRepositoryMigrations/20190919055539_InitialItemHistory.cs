using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fateblade.Haushaltsbuch.Data.DataStoring.SqLite.Migrations.ItemHistorySqLiteRepositoryMigrations
{
    public partial class InitialItemHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LastBuyDate = table.Column<DateTime>(nullable: false),
                    DateOfChange = table.Column<DateTime>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    PricePerUnit = table.Column<decimal>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemHistories", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemHistories");
        }
    }
}
